using Microsoft.AspNetCore.Mvc;
using MVCPeopleDatabase.Models.Repo;
using MVCPeopleDatabase.Models.Services;
using MVCPeopleDatabase.Models.ViewModels;
using NuGet.Protocol;
using System.Net;
using System;
using MVCPeopleDatabase.Models;


namespace MVCPeopleDatabase.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IpeopleService _peopleService;//field we defined the dependency here and in the line 20 we inject the dependency
        private readonly ICityService _cityService;//field
        public PeopleController(IpeopleService peopleService, ICityService cityService)
        {
            //_countryService = new PeopleService(new InMemoryPeopleRepo());
            _peopleService = peopleService;
            _cityService = cityService;
        }



        public IActionResult PersonPage()
        {
            return View(_peopleService.FindAllPeople());
        }

        [HttpGet]
        public IActionResult Add()
        {

            CreatePersonViewModel viewModel = new CreatePersonViewModel();
           // viewModel.c = _cityService.AllCity();
            return View(viewModel);
        }

        [HttpPost] 
        [AutoValidateAntiforgeryToken]
        public IActionResult Add(CreatePersonViewModel addPerson)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _peopleService.Add(addPerson);
                }
                catch (ArgumentException exception)
                {
                    ModelState.AddModelError("Name /*and CityName*/", exception.Message);
                    return View(addPerson);
                }

                //after adding the person, with this line of code it goes back to the whole list, 
                //otherwise it will stay in the same form and you can not see the information you submitted.
                return RedirectToAction(nameof(PersonPage));
            }
            return View(addPerson);
        }

       // Details Button
        public IActionResult Details(int id)
        {
            Person person = _peopleService.FindById(id);

            if (person == null)
            {
                return RedirectToAction(nameof(PersonPage));
            }

            return View(person);
        }

        //Edit Button
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(int id)
        {
            Person person = _peopleService.FindById(id);
            if (person == null)
            {
                return RedirectToAction(nameof(PersonPage));
            }
            CreatePersonViewModel editPerson = new CreatePersonViewModel();
            {

                editPerson.Name = person.Name;
                editPerson.PhoneNumber = person.PhoneNumber;
                editPerson.CityId = person.CityId;
            }
            return View(editPerson);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public IActionResult Edit(int id, CreatePersonViewModel editPerson)
        {
            if (ModelState.IsValid)
            {
                _peopleService.Edit(id, editPerson);
                return RedirectToAction(nameof(PersonPage));
            }
            _peopleService.Add(editPerson);
            return View(editPerson);
        }

        //Delete Button
        public IActionResult Delete(int id)
        {

            Person person = _peopleService.FindById(id);

            if (person == null)
            {
                return RedirectToAction(nameof(PersonPage));
            }
            else
            {
                _peopleService.Remove(id);
            }

            return View(person);

        }

        //[HttpPost]
        //public IActionResult FindPersonsByCityName(string cityName)
        //{
        //    if (cityName != null)
        //    {
        //       var foundCity = _cityService.FindByCity(cityName);
        //        return View(_peopleService.FindByCity(foundCity));
        //    }
        //    return RedirectToAction(nameof(PersonPage));
        //}

        //This is for ajaxListOfPoeple-get-function in Ajax.
        public IActionResult PartialViewPeople()
        {

            return PartialView("_PeopleList", _peopleService.FindAllPeople());
        }

        [HttpPost]
        public IActionResult PartialViewDetails(int id)
        {
            Person personVariable = _peopleService.FindById(id);
            if (personVariable != null)//means if you found the person
            {
                return PartialView("_personDisplay", personVariable);
            }
            return NotFound();
        }


        public IActionResult Ajax(int id)
        {
            Person person = _peopleService.FindById(id);
            if (_peopleService.Remove(id))
            {
                return PartialView("_peopleList", _peopleService.FindAllPeople());
            }
            return NotFound();
        }


        //public IActionResult SearchCity(string cityname)
        //{
        //    List<Person> person = _countryService.FindByCity(cityname);
        //    if (person != null)
        //    {
        //        return PartialView("_peopleList", person);

        //    }
        //    return BadRequest();

        //}


    } 
}
