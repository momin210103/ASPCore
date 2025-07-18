using Microsoft.AspNetCore.Mvc;
using NewsApp.Services;

namespace NewsApp.Controllers
{
    public class HomeController: Controller
    {
        private readonly NewsService _newsService;
        public HomeController(NewsService newsService)
        {
            _newsService = newsService;
        }
        [Route("/")]
        public async Task<IActionResult> Index()
        {
            _newsService.GetNews();
            return View();
        }
    }
}
