using Microsoft.AspNetCore.Mvc;
using Services;
using ServiceContracts;
namespace DI.Controllers
{
    public class HomeController: Controller
    {
        // constructor injection
        private readonly ICitiesService _citiesService1;
        private readonly ICitiesService _citiesService2;
        private readonly ICitiesService _citiesService3;

        public HomeController(ICitiesService citiesService1, ICitiesService citiesService2, ICitiesService citiesService3)
        {
            _citiesService1 = citiesService1; //new CitiesService();
            _citiesService2 = citiesService2;
            _citiesService3 = citiesService3;
        }

        [Route("/")]
        public IActionResult Index()
        {

            List<string> cities = _citiesService1.GetCities();
            ViewBag.ServiceInstanceId1 = _citiesService1.ServiceInstanceId;
            ViewBag.ServiceInstanceId2 = _citiesService2.ServiceInstanceId;
            ViewBag.ServiceInstanceId3 = _citiesService3.ServiceInstanceId;

            return View(cities);
        }
    }
}
