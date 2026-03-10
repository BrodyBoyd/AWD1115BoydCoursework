using Microsoft.AspNetCore.Mvc;

namespace HOT3.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
