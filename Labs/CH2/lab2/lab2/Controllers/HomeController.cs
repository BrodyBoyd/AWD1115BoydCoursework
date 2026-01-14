using Microsoft.AspNetCore.Mvc;
using lab2.Models;

namespace lab2.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(PriceQuotationCalculator Price)
        {
            if (ModelState.IsValid)
            {
                ViewBag.DiscountAmount = Price.GetDiscountTotal();
                ViewBag.Total = Price.CalculatePrice();
            }
            else
            {
                ViewBag.DiscountAmount = 0;
                ViewBag.Total = 0;
            }
            return View(Price);
        }
    }
}
