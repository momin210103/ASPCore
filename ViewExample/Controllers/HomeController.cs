using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using ViewExample.Models;

namespace ViewExample.Controllers
{
    public class HomeController: Controller
    {
        [Route("home")]
        [Route("/")]
        public IActionResult Index()
        {
            ViewData["appTitle"] = "ASP.NET Core MVC Example";
            List<Person> people = new List<Person>
            {
                new Person (){ name = "Alice", age = 30 },
                new Person (){ name = "Bob", age = 25 },
                new Person (){ name = "Charlie", age = 35 }

            };
            ViewData["people"] = people;
            return View();//Views/Home/Index.cshtml
            //return new ViewResult() { ViewName = "abc" };
        }

    }
}
