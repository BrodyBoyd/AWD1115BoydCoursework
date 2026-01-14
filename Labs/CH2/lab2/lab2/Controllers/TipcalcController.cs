using lab2.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab2.Controllers
{
    public class TipcalcController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(TipCalculator Price)
        {
            if (ModelState.IsValid)
            {
                ViewBag.FifteenTip = Price.getFifteen();
                ViewBag.TwentyTip = Price.getTwenty();
                ViewBag.TwentyFiveTip = Price.getTwentyFive();
            }
            else
            {
                ViewBag.FifteenTip = 0;
                ViewBag.TwentyTip = 0;
                ViewBag.TwentyFiveTip = 0;
            }
            return View(Price);
        }
    }
}
