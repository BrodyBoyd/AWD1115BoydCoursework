using HOT4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HOT4.Controllers
{
    public class HomeController(AppointmentContext context) : Controller
    {
        private readonly AppointmentContext _context = context;

        public async Task<IActionResult> Index()
        {
            var appointments = await _context.Appointments
                .Include(a => a.customer)
                .ToListAsync();

            return View(appointments);
        }
    }
}
