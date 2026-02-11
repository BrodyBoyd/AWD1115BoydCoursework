using Microsoft.AspNetCore.Mvc;

namespace Ch7Lab.Areas.Help.Controllers
{
    [Area("Help")]
    public class TutorialController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
