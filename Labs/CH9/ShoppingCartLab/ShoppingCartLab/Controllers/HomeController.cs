using Microsoft.AspNetCore.Mvc;

namespace ShoppingCartLab.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
