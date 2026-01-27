using Microsoft.AspNetCore.Mvc;

namespace PeePal.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }
        public IActionResult Contact()
        {
            ViewBag.Title = "Contact";
            return View();
        }
        public IActionResult RateRestroom()
        {
            ViewBag.Title = "Rate a Restroom";
            return View();
        }
    }
}
