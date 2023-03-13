using RestWithASPNET.Model;
using RestWithASPNET.Repository;

namespace RestWithASPNET.Services.Implementations
{
    public class BookServiceImplementation: IBookService
    {
        private IBookRepository _bookRepository;

        public BookServiceImplementation(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public List<Book> FindAll()
        {
            return _bookRepository.FindAll();
        }

        public Book FindById(long id)
        {
            return _bookRepository.FindById(id);
        }

        public Book Create(Book book)
        {
            return _bookRepository.Create(book);
        }

        public Book Update(Book book)
        {
            return _bookRepository.Update(book);
        }

        public void Delete(long id)
        {
            _bookRepository.Delete(id);
        }
    }
}
