
using BookApp.Domain;

namespace BookApp.DataAccess
{
    public class BookRepository : IRepository<Book>
    {
        private BookAppDbContext _dbContext;

        public BookRepository(BookAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Book entity)
        {
            _dbContext.Books.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(Book entity)
        {
            _dbContext.Books.Remove(entity);
            _dbContext.SaveChanges();

        }

        public List<Book> GetAll()
        {
            var books = _dbContext.Books.ToList();
            return books;
        }

        public Book GetById(int id)
        {
            var book = _dbContext.Books.FirstOrDefault(x => x.Id == id);
            return book;
        }

        public void Update(Book entity)
        {
            _dbContext.Books.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
