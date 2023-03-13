using RestWithASPNET.Model;

namespace RestWithASPNET.Services
{
    public interface IBookService
    {
        List<Book> FindAll();
        Book FindById(long id);
        Book Create(Book book);
        Book Update(Book book);
        void Delete(long id);
    }
}
