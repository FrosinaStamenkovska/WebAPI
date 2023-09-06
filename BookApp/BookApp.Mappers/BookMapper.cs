using BookApp.Domain;
using BookApp.Dtos;

namespace BookApp.Mappers
{
    public static class BookMapper
    {
        public static BookDto ToDto (this Book book)
        {
            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
            };
        }

        public static Book ToDomain(this AddBookDto book)
        {
            return new Book
            {
                Title = book.Title,
                Author = book.Author,
            };
        }
    }
}