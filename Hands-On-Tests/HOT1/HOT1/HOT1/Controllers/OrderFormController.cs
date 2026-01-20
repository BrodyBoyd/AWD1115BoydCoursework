using HOT1.Models;
using Microsoft.AspNetCore.Mvc;

namespace HOT1.Controllers
{
    public class OrderFormController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(OrderForm OrderForm)
        {
            if (ModelState.IsValid)
            {
                ViewBag.CodeResponse = OrderForm.CheckCode();
                ViewBag.Response = OrderForm.GetOrder();
            }
            else
            {
                ViewBag.CmLength = 0;
                ViewBag.Inches = 0;
            }
            return View(OrderForm);
        }
    }
}
