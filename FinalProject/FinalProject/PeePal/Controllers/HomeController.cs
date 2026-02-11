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

        [Route("Contact")]
        public IActionResult Contact()
        {
            ViewBag.Title = "Contact";
            return View();
        }

        [Route("About")]
        public IActionResult About()
        {
            ViewBag.Title = "About";
            return View();
        }

        public IActionResult RateRestroom()
        {
            ViewBag.Title = "Rate a Restroom";
            return View();
        }
    }
}
