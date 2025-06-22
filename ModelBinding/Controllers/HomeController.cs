using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using ModelBinding.Models;

namespace ModelBinding.Controllers
{
    public class HomeController: Controller
    {
        [Route("bookstore")]
        public IActionResult Index(int? bookId, bool? isloggedin, Book book)
        {
            if(bookId.HasValue == false)
            {
                return BadRequest("Book ID is required.");
            }
            if(bookId < 1)
            {
                return BadRequest("Book ID must be greater than 0.");
            }
            if(isloggedin == false)
            {
                return BadRequest("Login status is required.");
            }
            return Content($"Book ID:{bookId}, Book Object:{book}");
        }
    }
}
