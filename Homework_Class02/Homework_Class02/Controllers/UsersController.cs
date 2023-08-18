using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework_Class02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<string>> GetAll()
        {
            var users = UserDb.Users;

            return Ok(users);
        }

        [HttpGet("index/{index}")]
        public ActionResult GetByIndex(int index)
        {
            try
            {
                if(index < 0)
                {
                    return BadRequest("The value for index cannot be negative number!");
                }

                if(index >= UserDb.Users.Count)
                {
                    return NotFound($"The element on index {index} does not exist!");
                }

                return Ok(UserDb.Users[index]);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured, try again later");
            }
            
        }
    }
}
