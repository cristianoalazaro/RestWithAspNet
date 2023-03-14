using RestWithASPNET.Data.VO;

namespace RestWithASPNET.Services
{
    public interface IBookService
    {
        List<BookVO> FindAll();
        BookVO FindById(long id);
        BookVO Create(BookVO book);
        BookVO Update(BookVO book);
        void Delete(long id);
    }
}
