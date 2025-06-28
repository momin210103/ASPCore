using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace ViewExample.Controllers
{
    public class HomeController: Controller
    {
        [Route("home")]
        [Route("/")]
        public IActionResult Index()
        {
            return View();//Views/Home/Index.cshtml
            //return new ViewResult() { ViewName = "abc" };
        }
        [Route("home/index2")]
        public IActionResult Index2()
        {
                return View();
            //return Content("Hello from Index2!");
            //return View("Index3");//Views/Home/Index.cshtml
            //return new ViewResult() { ViewName = "abc" };
        }
        [Route("home/view")]
        public IActionResult Index3()
        {
            //return View();//Views/Home/Index.cshtml
            return new ViewResult() { ViewName = "Index2" };
        }
    }
}
