using FluentValidation;
using HOT4.Models;
using Microsoft.AspNetCore.Mvc;

namespace HOT4.Controllers
{
    public class CustomerController(AppointmentContext context, IValidator<Customer> _customerValidator) : Controller
    {
        private readonly AppointmentContext _context = context;

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            var result = await _customerValidator.ValidateAsync(customer);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(customer);
            }
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(customer);
        }
    }
}
