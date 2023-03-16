using RestWithASPNET.Data.Converter.Implementations;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Model;
using RestWithASPNET.Repository.Generic;
using RestWithASPNET.Utils;

namespace RestWithASPNET.Services.Implementations
{
    public class BookServiceImplementation: IBookService
    {
        private IRepository<Book> _bookRepository;
        private BookConverter _converter;

        public BookServiceImplementation(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
            _converter = new BookConverter();
        }

        public List<BookVO> FindAll(ParamsPagination paramsPagination)
        {
            return _converter.Parse(_bookRepository.FindAll(paramsPagination));
        }

        public BookVO FindById(long id)
        {
            return _converter.Parse(_bookRepository.FindById(id));
        }

        public BookVO Create(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _bookRepository.Create(bookEntity);
            return _converter.Parse(bookEntity);
        }

        public BookVO Update(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _bookRepository.Update(bookEntity);
            return _converter.Parse(bookEntity);
        }

        public void Delete(long id)
        {
            _bookRepository.Delete(id);
        }
    }
}
