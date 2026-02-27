using Microsoft.AspNetCore.Mvc;

namespace ShoppingCartLab.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
