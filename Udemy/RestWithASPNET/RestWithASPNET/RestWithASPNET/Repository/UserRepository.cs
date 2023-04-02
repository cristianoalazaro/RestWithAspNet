using RestWithASPNET.Data.VO;
using RestWithASPNET.Model;
using RestWithASPNET.Model.Context;
using System.Security.Cryptography;
using System.Text;

namespace RestWithASPNET.Repository;

public class UserRepository : IUserRepository
{
    private readonly MySQLContext _context;

    public UserRepository(MySQLContext context)
    {
        _context = context;
    }

    public User ValidateCredentials(UserVO user)
    {
        var pass = ComputeHash(user.Password, SHA256.Create());
        return _context.Users.FirstOrDefault(u => u.UserName == user.UserName && u.Password == pass);
    }

    public User ValidateCredentials(string userName)
    {
        return _context.Users.FirstOrDefault(u => u.UserName.Equals(userName));
    }

    public bool RevokeToken(string username)
    {
        var user = _context.Users.FirstOrDefault(u =>  u.UserName.Equals(username));
        if (user is null) return false;
        user.RefreshToken = null;
        _context.SaveChanges();
        return true;
    }

    public User RefreshUserInfo(User user)
    {
        if (!_context.Users.Any(u => u.Id.Equals(user.Id))) return null;

        var result = _context.Users.SingleOrDefault(u => u.Id.Equals(user.Id));
        if (result != null)
        {
            try
            {
                _context.Users.Entry(result).CurrentValues.SetValues(user);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        return result;
    }


    private string ComputeHash(string password, SHA256 algorithm)
    {
        byte[] inputBytes = Encoding.UTF8.GetBytes(password);
        byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
        return BitConverter.ToString(hashedBytes);
    }
}
