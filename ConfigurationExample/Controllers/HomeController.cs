using Microsoft.AspNetCore.Mvc;

namespace ConfigurationExample.Controllers
{
    public class HomeController: Controller
    {

        //private readonly 
        private readonly IConfiguration _configuration;

        //constructor

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [Route("/")]
        public IActionResult Index()
        {
            //ViewBag.MyKey = _configuration["weatherapi:ClientID"]; 
            //ViewBag.Myapikey = _configuration.GetValue("weatherapi:ClientSecret", "50");

            //ViewBag.MyKey = _configuration.GetSection("weatherapi")["ClientID"];
            //ViewBag.Myapikey = _configuration.GetSection("weatherapi")["ClientSecret"];

            // Using GetSection to retrieve a section of the configuration
            //IConfiguration weartherapi = _configuration.GetSection("weatherapi");
            //ViewBag.MyKey = weartherapi["ClientID"];
            //ViewBag.Myapikey = weartherapi["ClientSecret"];



            // ? Recomended method options patten

            // Get MeteorApiOptions from the configuration
            //WeatherApiOptions options = _configuration.GetSection("weatherapi").Get<WeatherApiOptions>(); // Recomended method


            //Usin Bind:

            WeatherApiOptions options = new WeatherApiOptions();
            _configuration.GetSection("weatherapi").Bind(options); // Using Bind to map configuration to the WeatherApiOptions class

            ViewBag.MyKey = options.ClientId;
            ViewBag.Myapikey = options.ClientSecret;




            // Hello //ViewBag.MyKey = _configuration["weatherapi:ClientID"];

            return View();
        }
    }
}
