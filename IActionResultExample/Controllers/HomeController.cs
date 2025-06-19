using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
    public class HomeController: Controller
    {
        [Route("book")]
        //Route book?isloggedin=true&bookid=1
        public IActionResult Index()
        {
            if (!Request.Query.ContainsKey("bookid"))
            {
                //Response.StatusCode = 400; // Bad Request
                //return Content("Book ID is not supllied.");
                return BadRequest("Book ID is not supplied.");
            }
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
                //Response.StatusCode = 400; // Bad Request
                //return Content("Book ID is empty.");
                return BadRequest("Book ID is empty.");
            }
            int bookId = Convert.ToInt16(ControllerContext.HttpContext.Request.Query["bookid"]);
            if (bookId <= 0)
            {
                //Response.StatusCode = 400; // Bad Request
                //return Content("Book ID cannot be less than or equal to zero.");
                return BadRequest("Book ID cannot be less than or equal to zero.");
            }
            if (bookId >1000)
            {
                //Response.StatusCode = 400; // Bad Request
                //return Content("Book ID cannot be greater than 1000.");
                return NotFound("Book ID cannot be greater than 1000.");
            }
            //isloggind should be true
            if(Convert.ToBoolean(Request.Query["isloggedin"]) == false)
            {
                //Response.StatusCode = 401; // Unauthorized
                //return Content("You are not authorized to view this book.");
                return Unauthorized("You are not authorized to view this book.");
            }
            return File("/sample.pdf", "application/pdf");
        }
    }
}
