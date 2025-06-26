using Microsoft.AspNetCore.Mvc;
using ModelValidationExample.Models;
using ModelValidationExample.CustomModelBinder;

namespace ModelValidationExample.Controllers
{
    [Route("register")]
    public class HomeController: Controller
    {

        //[Bind(nameof(Person.PersonName), nameof(Person.Email), nameof(Person.Password), nameof(Person.ConfirmPassword))]
        //[ModelBinder(BinderType = typeof(PersonModelBinder)]
        public IActionResult Index(Person person)
        {
            if (!ModelState.IsValid)
            {
                //List<string> errorsList = new List<string>();
                //foreach (var value in ModelState.Values)
                //{
                //    foreach (var error in value.Errors)
                //    {
                //        errorsList.Add(error.ErrorMessage);
                //    }
                //}
                //string errors = string.Join("\n", errorsList);
                //int totalErrors = errorsList.Count;

                // Another Way 
                string errors = string.Join("\n",ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage));
                int totalErrors = ModelState.Values.Sum(value => value.Errors.Count);

                return BadRequest(errors);
            }
            return Content($"{person}");
        }
    }
}
