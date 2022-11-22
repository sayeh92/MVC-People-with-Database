using Microsoft.AspNetCore.Mvc;
using MVCPeopleDatabase.Models.Repo;
using MVCPeopleDatabase.Models.Services;
using MVCPeopleDatabase.Models.ViewModels;
using NuGet.Protocol;
using System.Net;
using System;
using Microsoft.AspNetCore.Identity;
using MVCPeopleDatabase.Models;

namespace MVCPeopleDatabase.Controllers
{
    public class PeopleController : Controller
    {
        IpeopleService _peopleService;
        public PeopleController()
        {
            _peopleService = new PeopleService(new InMemoryPeopleRepo());
        }



        public IActionResult PersonPage()
        {
            return View(_peopleService.All());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new CreatePersonViewModel());
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
                    ModelState.AddModelError("Name and CityName", exception.Message);
                    return View(addPerson);
                }

                //after adding the person, with this line of code it goes back to the whole list, 
                //otherwise it will stay in the same form and you can not see the information you submitted.
                return RedirectToAction(nameof(PersonPage));
            }
            return View(addPerson);
        }

        //Details Button
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
                editPerson.CityName = person.CityName;
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

        [HttpPost]
        public IActionResult PersonPage(string search)
        {
            if (search != null)
            {
                return View(_peopleService.Search(search));
            }
            return RedirectToAction(nameof(PersonPage));
        }

        //This is for ajaxListOfPoeple-get-function in Ajax. 
        public IActionResult PartialViewPeople()
        {

            return PartialView("_PeopleList", _peopleService.All());
        }
        
        [HttpPost]
        public IActionResult PartialViewDetails(int id)
        {
            Person person = _peopleService.FindById(id);
            if (person != null)
            {
                return PartialView("_personDisplay", person);
            }
            return NotFound();
        }


        public IActionResult Ajax(int id)
        {
            Person person = _peopleService.FindById(id);
            if (_peopleService.Remove(id))
            {
                return PartialView("_peopleList", _peopleService.All());
            }
            return NotFound();
        }


        public IActionResult SearchCity(string cityname)
        {
            List<Person> person = _peopleService.FindByCity(cityname);
            if (person != null)
            {
                return PartialView("_peopleList", person);

            }
            return BadRequest();

        }

       
    } 
}
