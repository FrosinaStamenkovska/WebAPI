using Homework_Class03.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework_Class03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var books = BooksDb.Books;

            try
            {
                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error happend, please try again");
            }
        }

        [HttpGet("get-by-index")]
        public IActionResult GetByIndex(int? index)
        {
            try
            {
                if (index < 0)
                {
                    return BadRequest("The index cannot be a negative number!");
                }

                if (index >= BooksDb.Books.Count)
                {
                    return NotFound($"The book on index {index} does not exist!");
                }

                return Ok(BooksDb.Books[index ?? 0]);
               
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error happend, please try again");
            }
        }

        [HttpGet("filter")]
        public IActionResult Filter(string? author, string? title)
        {
            try
            {
                var query = BooksDb.Books;

                // Case 1 (If more than 1 book can be returned and query param doesn't need to be exact match with the found result)

                if (!string.IsNullOrEmpty(author))
                {
                    query = query.Where(x => x.Author.ToLower().Contains(author.ToLower())).ToList();

                }

                if (!string.IsNullOrEmpty(title))
                {
                    query = query.Where(x => x.Title.ToLower().Contains(title.ToLower())).ToList();

                }

                if (query.Count < 1)
                {
                    return NotFound($"A book with searched title and author doesn't exist!");
                }

                return Ok(query);

                // Case 2 (If only 1 book should be returned and query param should be exact match)

                //if (!string.IsNullOrEmpty(author))
                //{
                //    query = query.Where(x => x.Author.ToLower() == author.ToLower()).ToList();

                //    if (query.Count < 1)
                //    {
                //        return NotFound($"There is no book found from the author {author}");
                //    }
                //}

                //if (!string.IsNullOrEmpty(title))
                //{
                //    query = query.Where(x => x.Title.ToLower() == title.ToLower()).ToList();

                //    if (query.Count < 1)
                //    {
                //        return NotFound($"There is no book found with title: {title}");
                //    }
                //}

                //return Ok(query.FirstOrDefault());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error happend, please try again");
            }
           
        }
    }
}
