using Homework_Class03.Models;

namespace Homework_Class03
{
    public static class BooksDb
    {
        public static List<Book> Books = new List<Book>()
        {
            new Book
            {
                Author = "William Shakespeare",
                Title = "Hamlet"
            },
            new Book
            {
                Author = "J. K. Rowling",
                Title = "Harry Potter"
            },
            new Book
            {
                Author = "Leo Tolstoy",
                Title = "War and Peace"
            },
            new Book
            {
                Author = "Paulo Coelho",
                Title = "The Alchemist"
            },
            new Book
            {
                Author = "George R. R. Martin",
                Title = "Game of Thrones"

            },
            new Book
            {
                Author = "Paulo Coelho",
                Title = "Eleven minutes"
            },
            new Book
            {
                Author = "Herbert George Wells",
                Title = "The War of the Worlds"
            },
        };
    }
}
