using RestWithASPNET.Data.VO;
using RestWithASPNET.Utils;

namespace RestWithASPNET.Services
{
    public interface IBookService
    {
        List<BookVO> FindAll(ParamsPagination paramsPagination);
        BookVO FindById(long id);
        BookVO Create(BookVO book);
        BookVO Update(BookVO book);
        void Delete(long id);
    }
}
