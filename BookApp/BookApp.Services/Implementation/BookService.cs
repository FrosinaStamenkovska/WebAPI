using BookApp.DataAccess;
using BookApp.Domain;
using BookApp.Dtos;
using BookApp.Mappers;
using BookApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Services.Implementation
{
    public class BookService : IBookService
    {
        private IRepository<Book> _bookRepository;

        public BookService(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void AddBook(AddBookDto book)
        {
            if(string.IsNullOrEmpty(book.Title))
            {
                throw new ArgumentNullException("The title is required!");
            }

            if(book.Title.Length > 500)
            {
                throw new InvalidDataException("Max length for title is 500 chars!");
            }

            if (string.IsNullOrEmpty(book.Author))
            {
                throw new ArgumentNullException("The author is required!");
            }

            if (book.Author.Length > 250)
            {
                throw new InvalidDataException("Max length for Author is 250 chars!");
            }

            if(_bookRepository.GetAll().Any(x => x.Title.ToLower() == book.Title.ToLower() && x.Author.ToLower() == book.Author.ToLower()))
            {
                throw new InvalidDataException($"A book with title: {book.Title} from author {book.Author} already exists!");
            }

            var bookDomain = book.ToDomain();
            _bookRepository.Add(bookDomain);
        }

        public void Delete(BookDto book)
        {
            var foundBook = _bookRepository.GetById(book.Id);
            if(foundBook == null)
            {
                throw new KeyNotFoundException($"Book with id {book.Id} does not exist");
            }
            _bookRepository.Delete(foundBook);
        }

        public List<BookDto> GetAll()
        {
            var books = _bookRepository.GetAll();
            if (books == null || books.Count < 1)
            {
                throw new KeyNotFoundException($"No books has been found!");
            }
            return books.Select(x => x.ToDto()).ToList();
        }

        public BookDto GetById(int id)
        {
            var book = _bookRepository.GetById(id);
            if (book == null)
            {
                throw new KeyNotFoundException($"Book with id {id} does not exist");
            }
            return book.ToDto();
        }

        public void Update(BookDto book)
        {
            var foundBook = _bookRepository.GetById(book.Id);
            if (foundBook is null)
            {
                throw new KeyNotFoundException($"Book with id {book.Id} does not exist");
            }
            
            if (string.IsNullOrEmpty(book.Title))
            {
                throw new ArgumentNullException("The title is required!");
            }

            if (book.Title.Length > 500)
            {
                throw new InvalidDataException("Max length for title is 500 chars!");
            }

            if (string.IsNullOrEmpty(book.Author))
            {
                throw new ArgumentNullException("The author is required!");
            }

            if (book.Author.Length > 250)
            {
                throw new InvalidDataException("Max length for Author is 250 chars!");
            }

            if (_bookRepository.GetAll().Any(x => x.Title == book.Title && x.Author == book.Author))
            {
                throw new InvalidDataException($"A book with title: {book.Title} from author {book.Author} already exists!");
            }

            foundBook.Author = book.Author;
            foundBook.Title = book.Title;
            _bookRepository.Update(foundBook);
        }

        public BookDto Filter (string author, string title)
        {
            var query = GetAll();
            if (!string.IsNullOrEmpty(author))
            {
                query = query.Where(x => x.Author.ToLower() == author.ToLower()).ToList();
            }

            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(x => x.Title.ToLower() == title.ToLower()).ToList();
            }

            if (query.Count < 1)
            {
                throw new KeyNotFoundException($"There is no such a book.");
            }

            return query.FirstOrDefault();

        }
    }
}
