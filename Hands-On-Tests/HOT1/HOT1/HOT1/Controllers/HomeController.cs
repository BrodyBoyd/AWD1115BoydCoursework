using HOT1.Models;
using Microsoft.AspNetCore.Mvc;

namespace HOT1.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(DistanceConverter Converter)
        {
            if (ModelState.IsValid)
            {
                ViewBag.CmLength = Converter.GetCm();
                ViewBag.Inches = Converter.Inches;
            }
            else
            {
                ViewBag.CmLength = 0;
                ViewBag.Inches = 0;
            }
            return View(Converter);
        }
    }
}
