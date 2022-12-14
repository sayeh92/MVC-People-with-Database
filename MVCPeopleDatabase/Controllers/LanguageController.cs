using Microsoft.AspNetCore.Mvc;

namespace MVCPeopleDatabase.Controllers
{
    public class LanguageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
