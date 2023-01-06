using Microsoft.AspNetCore.Mvc;
using MVCPeopleDatabase.Models;
using MVCPeopleDatabase.Models.Services;
using MVCPeopleDatabase.Models.ViewModels;

namespace MVCPeopleDatabase.Controllers
{
    public class CountryController : Controller
    {
         readonly ICountryService _countryService;
        public CountryController(ICountryService countryService) 
        {
            _countryService = countryService;
        }
        public IActionResult Index()
        {
            return View(_countryService.FindAllCountry());
        }
       

        [HttpGet]
        public IActionResult Add()
        {

            CreateCountryViewModel countryModel = new CreateCountryViewModel();
            //viewModel.Cities = _cityService.AllCity();
            return View(countryModel);
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult CreateCountry(CreateCountryViewModel addCountry)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _countryService.CreateCountry(addCountry);
                }
                catch (ArgumentException exception)
                {
                    ModelState.AddModelError("Error", exception.Message);
                    return View(addCountry);
                }

                //after adding the person, with this line of code it goes back to the whole list, 
                //otherwise it will stay in the same form and you can not see the information you submitted.
                return RedirectToAction(nameof(Index));
            }
            return View(addCountry);
        }

        public IActionResult Details(int id)
        {
            Country country = _countryService.FindCountryById(id);

            if (country == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(country);
        }

        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(int id)
        {
            Country country = _countryService.FindCountryById(id);
            if (country == null)
            {
                return RedirectToAction(nameof(Index));
            }
            CreateCountryViewModel editCountry = new CreateCountryViewModel();
            {

                editCountry.Name = country.Name;
               // editCountry.id = id;
            }
            return View(editCountry);
        }

        [HttpPut]
        [AutoValidateAntiforgeryToken]

        public IActionResult Edit(int id, CreateCountryViewModel editCountry)
        {
            if (ModelState.IsValid)
            {
                _countryService.UpdateCountry(id, editCountry);
                return RedirectToAction(nameof(Index));
            }
            _countryService.CreateCountry(editCountry);
            return View(editCountry);
        }

        public IActionResult Delete(int id)
        {

            Country country = _countryService.FindCountryById(id);

            if (country == null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                _countryService.RemoveCountryById(id);
            }

            return View(country);

        }
    }
}
