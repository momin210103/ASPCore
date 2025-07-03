using Microsoft.AspNetCore.Mvc;
using RazorView.Models;

namespace RazorView.Controllers
{
    public class HomeController: Controller
    {
        [Route("/home")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
