using Microsoft.AspNetCore.Mvc;

namespace PeePal.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult RateRestroom()
        {
            return View();
        }
    }
}
