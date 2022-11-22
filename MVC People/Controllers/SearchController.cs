using Microsoft.AspNetCore.Mvc;

namespace MVC_People.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
