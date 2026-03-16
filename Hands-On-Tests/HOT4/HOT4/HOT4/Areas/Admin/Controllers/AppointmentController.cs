using FluentValidation;
using HOT4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppointmentController : Controller
    {
        private readonly AppointmentContext _context;
        private readonly IValidator<Appointment> _appointmentValidator;

        public AppointmentController(AppointmentContext context, IValidator<Appointment> appointmentValidator)
        {
            _context = context;
            _appointmentValidator = appointmentValidator;
        }

        public IActionResult Index()
        {
            var model = _context.Appointments
                .Include(a => a.customer)
                .ToList();

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var customers = await _context.Customers
                .Select(c => new { c.CustomerId, c.Username })
                .ToListAsync();

            ViewBag.Customers = customers
                .Select(c => new SelectListItem { Value = c.CustomerId.ToString(), Text = c.Username })
                .ToList();
            var appointment = await _context.Appointments.FindAsync(id);
            return View(appointment);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Appointment appointment)
        {
            var customers = await _context.Customers
                .Select(c => new { c.CustomerId, c.Username })
                .ToListAsync();
            ViewBag.Customers = customers
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
                _context.Appointments.Update(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(appointment);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            return View(appointment);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}