namespace RestWithASPNET.Utils;

public class ParamsPagination
{
    const int maxPageSize = 50;
    public int PageNumber { get; set; }
    int _pageSize = 10;

    public int PageSize
    {
        get
        {
            return _pageSize;
        }
        set
        {
            _pageSize = value > maxPageSize ? maxPageSize : value;
        }
    }
}
