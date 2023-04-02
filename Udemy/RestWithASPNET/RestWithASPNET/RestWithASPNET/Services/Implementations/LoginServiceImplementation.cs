using Microsoft.IdentityModel.JsonWebTokens;
using RestWithASPNET.Configurations;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Repository;
using System.Security.Claims;

namespace RestWithASPNET.Services.Implementations;

public class LoginServiceImplementation : ILoginService
{
    private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
    private TokenConfiguration _configuration;
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;

    public LoginServiceImplementation(TokenConfiguration configuration, IUserRepository userRepository, ITokenService tokenService)
    {
        _configuration = configuration;
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    public TokenVO ValidateCredentials(UserVO userCredentials)
    {
        var user = _userRepository.ValidateCredentials(userCredentials);
        if (user == null) return null;
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
        };

        var accessToken = _tokenService.GenerateAccessToken(claims);
        var refreshToken = _tokenService.GenerateRefreshToken();

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.Now.AddDays(_configuration.DaysToExpiry);

        _userRepository.RefreshUserInfo(user);

        DateTime createDate = DateTime.Now;
        DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);

        return new TokenVO(
            true,
            createDate.ToString(DATE_FORMAT),
            expirationDate.ToString(DATE_FORMAT),
            accessToken,
            refreshToken
            );
    }

    public TokenVO ValidateCredentials(TokenVO token)
    {
        var accessToken = token.AccessToken;
        var refreshToken = token.RefreshToken;
        var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);
        var userName = principal.Identity.Name;
        var user = _userRepository.ValidateCredentials(userName);

        if (user == null 
            || user.RefreshToken != refreshToken 
            || user.RefreshTokenExpiryTime <= DateTime.Now
            ) return null;

        accessToken = _tokenService.GenerateAccessToken(principal.Claims);
        refreshToken = _tokenService.GenerateRefreshToken();

        user.RefreshToken = refreshToken;

        _userRepository.RefreshUserInfo(user);

        DateTime createDate = DateTime.Now;
        DateTime expirationDate = DateTime.Now.AddDays(_configuration.Minutes);

        return new TokenVO(
            true,
            createDate.ToString(DATE_FORMAT),
            expirationDate.ToString(DATE_FORMAT),
            accessToken,
            refreshToken);
    }

    public bool RevokeToken(string username)
    {
        return _userRepository.RevokeToken(username);
    }
}
