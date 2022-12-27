using Microsoft.AspNetCore.Mvc;
using MVCPeopleDatabase.Models.Services;
using MVCPeopleDatabase.Models.ViewModels;
using MVCPeopleDatabase.Models;

namespace MVCPeopleDatabase.Controllers
{
    public class LanguageController : Controller
    {

        private readonly ILanguageService _languageService;
        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }
        public IActionResult Index()
        {
            return View(_languageService.AllLanguage());
        }


        [HttpGet]
        public IActionResult Add()
        {

            CreateLanguageViewModel languageModel = new CreateLanguageViewModel();
            
            return View(languageModel);
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Add(CreateLanguageViewModel addLanguage)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _languageService.Add(addLanguage);
                }
                catch (ArgumentException exception)
                {
                    ModelState.AddModelError("Name /*and CityName*/", exception.Message);
                    return View(addLanguage);
                }

                //after adding the person, with this line of code it goes back to the whole list, 
                //otherwise it will stay in the same form and you can not see the information you submitted.
                return RedirectToAction(nameof(Index));
            }
            return View(addLanguage);
        }

        public IActionResult Details(int id)
        {
            Language language = _languageService.FindLanguage(id);

            if (language == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(language);
        }

        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(int id)
        {
            Language language = _languageService.FindLanguage(id);
            if (language == null)
            {
                return RedirectToAction(nameof(Index));
            }
            CreateLanguageViewModel editLanguage = new CreateLanguageViewModel();
            {

                editLanguage.LanguageName = language.LanguageName;
                // editCountry.id = id;
            }
            return View(editLanguage);
        }

        [HttpPut]
        [AutoValidateAntiforgeryToken]

        public IActionResult Edit(int id, CreateLanguageViewModel editLanguage)
        {
            if (ModelState.IsValid)
            {
                _languageService.Update(id, editLanguage);
                return RedirectToAction(nameof(Index));
            }
            _languageService.Add(editLanguage);
            return View(editLanguage);
        }

        public IActionResult Delete(int id)
        {

            Language language = _languageService.FindById(id);

            if (language == null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                _languageService.RemoveById(id);
            }

            return View(language);

        }

    }
}
