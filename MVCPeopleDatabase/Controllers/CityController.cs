using Microsoft.AspNetCore.Mvc;
using MVCPeopleDatabase.Models;
using MVCPeopleDatabase.Models.Services;
using MVCPeopleDatabase.Models.ViewModels;
using System.Collections.Generic;

namespace MVCPeopleDatabase.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _cityService;
       

        public CityController(ICityService cityService)
        {

            _cityService = cityService;
        }
        public IActionResult Index()
        {
            return View(_cityService.AllCity());
        }

        [HttpGet]
        public IActionResult CreateCity()
        {
            return View(new CreateCityViewModel());
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult CreateCity(CreateCityViewModel createCity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _cityService.CreateCity(createCity);
                }
                catch (ArgumentException exception)
                {
                    ModelState.AddModelError("Name /*and CityName*/", exception.Message);
                    return View(createCity);
                }

                //after adding the person, with this line of code it goes back to the whole list, 
                //otherwise it will stay in the same form and you can not see the information you submitted.
                return RedirectToAction(nameof(createCity));
            }
            return View(createCity);
        }

        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public IActionResult EditCity(int id)
        {
            City city = _cityService.FindCityById(id);
            if (city == null)
            {
                return RedirectToAction(nameof(Index));
            }
            CreateCityViewModel editCity = new CreateCityViewModel();
            {

                editCity.CityName = editCity.CityName;
               
            }
            return View(editCity);
        }
        public IActionResult DeleteCity(int id)
        {

            City city = _cityService.FindCityById(id);

            if (city == null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                _cityService.RemoveCity(id);
            }

            return View(city);

        }
    }
}
