using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NewsApp.Services;

namespace NewsApp.Controllers
{
    public class HomeController: Controller
    {
        private readonly NewsService _newsService;
        private readonly IOptions<options> _options;
        public HomeController(NewsService newsService,IOptions<options>options)
        {
            _newsService = newsService;
            _options = options;
        }
        [Route("/")]
        public async Task<IActionResult> Index()
        {
            Dictionary<string,object>? responseDictionary = await _newsService.GetNews("AAPL");
            return View();
        }
    }
}
