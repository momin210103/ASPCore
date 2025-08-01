using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using ServiceContracts;
using ServiceContracts.DTO;
using System.IO;

namespace CRUDExample.Controllers
{
    public class PersonsController: Controller
    {
        //private fields

        private readonly IPersonsService _personsService;
        private readonly ICountriesService _countriesService;

        //constructor
        public PersonsController(IPersonsService personsService, ICountriesService countriesService)
        {
            _personsService = personsService;
            _countriesService = countriesService;
        }
        [Route("persons/index")]
        [Route("/")]
        public IActionResult Index(string searchBy,string? searchString)
        {
            ViewBag.SearchFields = new Dictionary<string, string>()
            {
                {nameof(PersonResponse.PersonName),"Person Name"},
                {nameof(PersonResponse.Email),"Email"},
                {nameof(PersonResponse.DateOfBirth),"Date of Birth"},
                {nameof(PersonResponse.Gender),"Gender"},
                {nameof(PersonResponse.Address),"Address"},
                {nameof(PersonResponse.CountryID),"Country"},

            }
            ;
            List<PersonResponse> persons = _personsService.GetFilteredPersons(searchBy,searchString);

            //Peserve the search fields
            ViewBag.CurrentSearchBy = searchBy;
            ViewBag.CurrentSearchString = searchString;

            return View(persons); //Views/Persons/Index.cshtml
        }

        //Executes when the user clicks on "Create Person" hyperlink while creating the create view

        [Route("persons/create")]
        [HttpGet]
        public IActionResult Create()
        {
            List<CountryResponse> countries = _countriesService.GetAllCountries();
            ViewBag.Countries = countries;
            return View();

        }

        [HttpPost]
        [Route("persons/create")]

        public IActionResult Create(PersonAddRequest personAddRequest)
        {
            if (!ModelState.IsValid)
            {
                List<CountryResponse> countries = _countriesService.GetAllCountries();
                ViewBag.Countries = countries;

                ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return View();
            }

            //call the service method
            PersonResponse personResponse = _personsService.AddPerson(personAddRequest);

            //navigate to Index() action method (it makes another get request to "persons/index"
            return RedirectToAction("Index", "Persons");


        }


        [Route("/personspdf")]
        public IActionResult PersonsPDF()
        {
            //Get list of Persons

           List<PersonResponse> persons =  _personsService.GetAllPersons();
            //Return View as pdf
            return new ViewAsPdf("PersonsPDF", persons, ViewData)
            {
                //Here Addition property of Pdf page
                PageMargins = new Rotativa.AspNetCore.Options.Margins()
                {
                    Top = 20,
                    Right = 20,
                    Bottom = 20,
                    Left = 20
                },
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape
            };
        }

        [Route("/peronscsv")]

        public async Task<IActionResult> PersonsCSV()
        {
            MemoryStream memoryStream = await _personsService.GetPersonsCSV();

            return File(memoryStream,"application/octet-stream","persons.csv");
        }
        [Route("/peronsexcel")]

        public async Task<IActionResult> PersonsExcel()
        {
            MemoryStream memoryStream = await _personsService.GetPersonsExcel();

            return File(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "persons.xlsx");
        }


    }
}
