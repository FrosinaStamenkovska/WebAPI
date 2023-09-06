using BookApp.Dtos;

namespace BookApp.Services.Interfaces
{
    public interface IBookService
    {
        List<BookDto> GetAll();
        BookDto GetById(int id);
        void AddBook(AddBookDto book);
        void Update(BookDto book);
        void Delete(BookDto book);

        BookDto Filter(string author, string title);
    }
}