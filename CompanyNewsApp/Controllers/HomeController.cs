using CompanyNewsApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CompanyNewsApp.Controllers
{
    public class HomeController: Controller
    {
        private readonly NewsService _newsService;
        public HomeController(NewsService newsService)
        {
            // Constructor logic can go here if needed
            _newsService = newsService;
        }
        [Route("/")]
        public async Task<IActionResult> Index()
        {
            _newsService.method();
            return View();
        }
    }
}
