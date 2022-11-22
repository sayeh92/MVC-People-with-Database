using Microsoft.AspNetCore.Mvc;

namespace MVCPeopleDatabase.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
