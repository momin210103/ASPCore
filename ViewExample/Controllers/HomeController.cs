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
            //ViewData["people"] = people;
            //ViewBag.people = people;
            return View("Index" , people);//Views/Home/Index.cshtml
            //return new ViewResult() { ViewName = "abc" };
        }
        [Route("person-Details/{name}")]
        public IActionResult Details(string? name)
        {
            if(name == null)
            {
                return Content("Name is null");
            }
            List<Person> people = new List<Person>
            {
                new Person (){ name = "Alice", age = 30 },
                new Person (){ name = "Bob", age = 25 },
                new Person (){ name = "Charlie", age = 35 }

            };
            Person? matchingPerson = people.Where(temp => temp.name == name).FirstOrDefault();
            return View(matchingPerson); //Views/Home/Details.cshtml

        }


    }
}
