using Microsoft.AspNetCore.Mvc;

namespace LayoutViewExample.Controllers
{
    public class ProductsController: Controller
    {
        [Route("products")]
        public IActionResult Index()
        {
            return View();
        }


        [Route("search-produtcs")]
        public IActionResult Search()
        {
            return View();
        }



        [Route("order-product")]
        public IActionResult Order()
        {
            return View();
        }

    }
}
