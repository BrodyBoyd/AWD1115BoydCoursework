using Lab8.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab8.Controllers
{
    public class HomeController : Controller
    {

        private readonly TripsContext _context;

        public HomeController(TripsContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var trips = _context.Trips.ToList();
            return View(trips);
        }
    }
}
