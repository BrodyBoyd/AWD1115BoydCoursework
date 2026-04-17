using Microsoft.AspNetCore.Mvc;

namespace HOT5.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
