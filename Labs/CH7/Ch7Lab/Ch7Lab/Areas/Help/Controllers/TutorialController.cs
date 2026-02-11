using Microsoft.AspNetCore.Mvc;

namespace Ch7Lab.Areas.Help.Controllers
{
    [Area("Help")]

    public class TutorialController : Controller
    {
        public IActionResult TutorialPages(int id)
        {
            ViewBag.PageTitle = "Tutorial Page";

            var viewName = $"Page{id}";

            if (id < 1 || id > 3)
                return NotFound();

            return View(viewName);
        }
    }
}
