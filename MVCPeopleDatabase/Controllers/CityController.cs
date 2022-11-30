using Microsoft.AspNetCore.Mvc;

namespace MVCPeopleDatabase.Controllers
{
    public class CityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
