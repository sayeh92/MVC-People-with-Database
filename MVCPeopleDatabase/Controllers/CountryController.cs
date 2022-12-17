using Microsoft.AspNetCore.Mvc;
using MVCPeopleDatabase.Models;
using MVCPeopleDatabase.Models.ViewModels;

namespace MVCPeopleDatabase.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;
        public CountryController(ICountryService countryService) 
        {
            _countryService = countryService;
        }
        public IActionResult Index()
        {
            return View(_countryService.All());
        }
       

        [HttpGet]
        public IActionResult Add()
        {

            CreatePersonViewModel viewModel = new CreatePersonViewModel();
            viewModel.Cities = _cityService.AllCity();
            return View(model);
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

        public IActionResult Details(int id)
        {
            Person person = _peopleService.FindById(id);

            if (person == null)
            {
                return RedirectToAction(nameof(PersonPage));
            }

            return View(person);
        }

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
                CityId = person.Id;
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
    }
}
