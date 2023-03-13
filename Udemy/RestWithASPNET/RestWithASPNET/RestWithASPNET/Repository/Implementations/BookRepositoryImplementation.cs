using RestWithASPNET.Model;
using RestWithASPNET.Model.Context;

namespace RestWithASPNET.Repository.Implementations
{
    public class BookRepositoryImplementation : IBookRepository
    {
        private MySQLContext _context;

        public BookRepositoryImplementation(MySQLContext context)
        {
            _context = context;
        }

        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }

        public Book FindById(long id)
        {
            return _context.Books.FirstOrDefault(b => b.Id.Equals(id));
        }

        public Book Create(Book book)
        {
            try
            {
                _context.Books.Add(book);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
            return book;
        }

        public Book Update(Book book)
        {
            if (book == null) return null;

            try
            {
                var result = _context.Books.FirstOrDefault(b => b.Id.Equals(book.Id));
                if (result != null)
                {
                    _context.Entry(result).CurrentValues.SetValues(book);
                    _context.SaveChanges(true);
                }
            }
            catch
            {
                throw;
            }
            return book;
        }

        public void Delete(long id)
        {
            var result = _context.Books.FirstOrDefault(b => b.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Books.Remove(result);
                    _context.SaveChanges();
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}
