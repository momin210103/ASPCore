using Microsoft.AspNetCore.Mvc;
using ControllerExample.Models;

namespace ControllerExample.Controllers
{
    [Controller]
    public class HomeController: Controller
    {
        [Route("home")] // attribute routing
        public ContentResult Index()
        {
            //return new ContentResult()
            //{
            //    Content = "Hello Index",
            //    ContentType = "PLain/Text"
            //};
            return Content("hello Index", "plain/text");
        }

        [Route("person")]
        public JsonResult Person()
        {
            Person person = new Person()
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                Age = 30
            };
            return Json(person); //Use this realworld scenario
            //return new JsonResult(person);
            //return "{\"key\":\"value\"}"; // JSON string

        }

        [Route("file-download")]
        public VirtualFileResult FileDownload()
        {
            //return new VirtualFileResult("/Momin.pdf","application/pdf");
            return File("/Momin.pdf", "application/pdf");
        }

        [Route("contact")]
        public string Contact()
        {
            return "Hello from Contact";
        }
    }
}
