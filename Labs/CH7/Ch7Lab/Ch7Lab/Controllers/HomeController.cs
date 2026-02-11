using Microsoft.AspNetCore.Mvc;

namespace Ch7Lab.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.PageTitle = "Home Page";
            return View();
        }
        public IActionResult About()
        {
            ViewBag.PageTitle = "About Page";

            return View();
        }
        public IActionResult Contact()
        {
            ViewBag.PageTitle = "Contact Page";

            return View();
        }
    }
}
