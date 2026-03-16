using FluentValidation;
using HOT4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HOT4.Controllers
{
    public class AppointmentController(AppointmentContext context, IValidator<Appointment> _appointmentValidator) : Controller
    {
        private readonly AppointmentContext _context = context;

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var customers = await _context.Customers
                .Select(c => new { c.CustomerId, c.Username })
                .ToListAsync();

            ViewBag.CustomerId = customers
                .Select(c => new SelectListItem { Value = c.CustomerId.ToString(), Text = c.Username })
                .ToList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Appointment appointment)
        {

            var customers = await _context.Customers
                .Select(c => new { c.CustomerId, c.Username })
                .ToListAsync();

            ViewBag.CustomerId = customers
                .Select(c => new SelectListItem { Value = c.CustomerId.ToString(), Text = c.Username })
                .ToList();
            var result = await _appointmentValidator.ValidateAsync(appointment);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(appointment);
            }
            if (ModelState.IsValid)
            {
                _context.Appointments.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(appointment);
        }
    }
}
