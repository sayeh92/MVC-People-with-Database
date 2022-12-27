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
        private readonly IpeopleService _countryService;//field we defined the dependency here and in the line 20 we inject the dependency
        private readonly ICityService _cityService;//field
        public PeopleController(IpeopleService peopleService, ICityService cityService)
        {
            //_countryService = new PeopleService(new InMemoryPeopleRepo());
            _countryService = peopleService;
            _cityService = cityService;
        }



        public IActionResult PersonPage()
        {
            return View(_countryService.FindAllPeople());
        }

        //[HttpGet]
        //public IActionResult Add()
        //{
         
        //    CreatePersonViewModel viewModel = new CreatePersonViewModel();
        //    viewModel. = _cityService.AllCity();
        //    return View(model);
        //}

        [HttpPost] 
        [AutoValidateAntiforgeryToken]
        public IActionResult Add(CreatePersonViewModel addPerson)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _countryService.Add(addPerson);
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

        //Details Button
        //public IActionResult Details(int id)
        //{
        //    Person person = _countryService.FindById(id);

        //    if (person == null)
        //    {
        //        return RedirectToAction(nameof(PersonPage));
        //    }

        //    return View(person);
        //}

        ////Edit Button
        //[HttpGet]
        //[AutoValidateAntiforgeryToken]
        //public IActionResult Edit(int id)
        //{
        //    Person person = _countryService.FindById(id);
        //    if (person == null)
        //    {
        //        return RedirectToAction(nameof(PersonPage));
        //    }
        //    CreatePersonViewModel editPerson = new CreatePersonViewModel();
        //    {

        //        editPerson.Name = person.Name;
        //        editPerson.PhoneNumber = person.PhoneNumber;
        //        CityId = person.Id;
        //    }
        //    return View(editPerson);
        //}

        //[HttpPost]
        //[AutoValidateAntiforgeryToken]

        //public IActionResult Edit(int id, CreatePersonViewModel editPerson)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _countryService.Edit(id, editPerson);
        //        return RedirectToAction(nameof(PersonPage));
        //    }
        //    _countryService.Add(editPerson);
        //    return View(editPerson);
        //}

        ////Delete Button
        //public IActionResult Delete(int id)
        //{

        //    Person person = _countryService.FindById(id);

        //    if (person == null)
        //    {
        //        return RedirectToAction(nameof(PersonPage));
        //    }
        //    else
        //    {
        //        _countryService.Remove(id);
        //    }

        //    return View(person);

        //}

        //[HttpPost]
        //public IActionResult PersonPage(string search)
        //{
        //    if (search != null)
        //    {
        //        return View(_countryService.Search(search));
        //    }
        //    return RedirectToAction(nameof(PersonPage));
        //}

        //This is for ajaxListOfPoeple-get-function in Ajax. 
        //public IActionResult PartialViewPeople()
        //{

        //    return PartialView("_PeopleList", _countryService.FindAllPeople());
        //}
        
        //[HttpPost]
        //public IActionResult PartialViewDetails(int id)
        //{
        //    Person personVariable = _countryService.FindById(id);
        //    if (personVariable != null)//means if you found the person
        //    {
        //        return PartialView("_personDisplay", personVariable);
        //    }
        //    return NotFound();
        //}


        //public IActionResult Ajax(int id)
        //{
        //    Person person = _countryService.FindById(id);
        //    if (_countryService.Remove(id))
        //    {
        //        return PartialView("_peopleList", _countryService.FindAllPeople());
        //    }
        //    return NotFound();
        //}


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
