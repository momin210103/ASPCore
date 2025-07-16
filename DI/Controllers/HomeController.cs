using Microsoft.AspNetCore.Mvc;
using Services;
using ServiceContracts;
namespace DI.Controllers
{
    public class HomeController: Controller
    {
        //! constructor injection
        //private readonly ICitiesService _citiesService;
        //public HomeController(ICitiesService citiesService)
        //{
        //    _citiesService = citiesService; //new CitiesService();
        //}

        [Route("/")]
        public IActionResult Index([FromServices] ICitiesService _citiesService)
        {

            List<string> cities = _citiesService.GetCities();

            return View(cities);
        }
    }
}
