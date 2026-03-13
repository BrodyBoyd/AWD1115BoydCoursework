using FluentValidation;
using Lab11.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Lab11.Controllers
{
    public class HomeController(ApplicationDbContext context, IValidator<Employee> _employeeValidator, IValidator<Sales> _salesValidator) : Controller
    {
        private readonly ApplicationDbContext _context = context;

        public IActionResult Index(int? SelectedEmployeeId)
        {
            var sales = new QuarterlySalesViewModel
            {
                Sales = _context.Sales
                    .Include(s => s.EmployeeRef)
                    .Where(s => !SelectedEmployeeId.HasValue || s.EmployeeId == SelectedEmployeeId.Value)
                    .ToList(),
                Employees = _context.Employees.ToList(),
                SelectedEmployeeId = SelectedEmployeeId
            };
            return View(sales);
        }

        [HttpGet]
        public async Task<IActionResult> AddSales()
        {
            var employees = await _context.Employees
                .Select(e => new { e.EmployeeId, Name = e.FirstName + " " + e.LastName })
                .ToListAsync();

            ViewBag.Employees = new SelectList(employees, "EmployeeId", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSales(Sales sales)
        {
            var result = await _salesValidator.ValidateAsync(sales);
            if (!result.IsValid)
            {
                foreach (var e in result.Errors)
                {
                    ModelState.AddModelError(e.PropertyName, e.ErrorMessage);
                }
            }
            if (ModelState.IsValid)
            {
                _context.Sales.Add(sales);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var employees = await _context.Employees
                .Select(e => new { e.EmployeeId, Name = e.FirstName + " " + e.LastName })
                .ToListAsync();
            ViewBag.Employees = new SelectList(employees, "EmployeeId", "Name", sales.EmployeeId);
            return View(sales);
        }

        [HttpGet]
        public async Task<IActionResult> AddEmployee()
        {
            var managers = await _context.Employees
                .Where(e => e.IsManager == true)
                .Select(e => new { e.EmployeeId, Name = e.FirstName + " " + e.LastName })
                .ToListAsync();

            ViewBag.Managers = new SelectList(managers, "EmployeeId", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            var result = await _employeeValidator.ValidateAsync(employee);
            var managers = await _context.Employees
                .Where(e => e.IsManager == true)
                .Select(e => new { e.EmployeeId, Name = e.FirstName + " " + e.LastName })
                .ToListAsync();

            ViewBag.Managers = new SelectList(managers, "EmployeeId", "Name");
            if (!result.IsValid)
            {
                foreach (var e in result.Errors)
                {
                    ModelState.AddModelError(e.PropertyName, e.ErrorMessage);
                }
            }

            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ValidateEmployeeField([FromBody] ValidateEmployeeFieldRequest request)
        {
            if (request == null)
            {
                return BadRequest(new { isValid = false, errors = new[] { "Invalid request" } });
            }

            var employee = new Employee
            {
                FirstName = request.FirstName ?? string.Empty,
                LastName = request.LastName ?? string.Empty,
                Birthday = request.Birthday ?? DateTime.MinValue,
                HireDate = request.HireDate ?? DateTime.MinValue
            };

            var result = await _employeeValidator.ValidateAsync(employee, options =>
                options.IncludeProperties(request.FieldName));

            return Json(new
            {
                isValid = result.IsValid,
                errors = result.Errors.Select(e => e.ErrorMessage)
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ValidateSaleField([FromBody] ValidateSaleFieldRequest request)
        {
            if (request == null)
            {
                return BadRequest(new { isValid = false, errors = new[] { "Invalid request" } });
            }

            var sale = new Sales
            {
                Quarter = request.Quarter ?? 0,
                Amount = request.Amount ?? 0.0,
                Year = request.Year ?? 0,
                EmployeeId = request.EmployeeId ?? 0
            };

            var result = await _salesValidator.ValidateAsync(sale, options =>
                options.IncludeProperties(request.FieldName));

            return Json(new
            {
                isValid = result.IsValid,
                errors = result.Errors.Select(e => e.ErrorMessage)
            });
        }

        public class ValidateEmployeeFieldRequest
        {
            [JsonPropertyName("fieldName")]
            public string FieldName { get; set; }

            [JsonPropertyName("FirstName")]
            public string? FirstName { get; set; }

            [JsonPropertyName("LastName")]
            public string? LastName { get; set; }

            [JsonPropertyName("Birthday")]
            public DateTime? Birthday { get; set; }

            [JsonPropertyName("HireDate")]
            public DateTime? HireDate { get; set; }
        }

        public class ValidateSaleFieldRequest
        {
            [JsonPropertyName("fieldName")]
            public string FieldName { get; set; }

            [JsonPropertyName("Quarter")]
            public int? Quarter { get; set; }

            [JsonPropertyName("Year")]
            public int? Year { get; set; }

            [JsonPropertyName("Amount")]
            public double? Amount { get; set; }

            [JsonPropertyName("EmployeeId")]
            public int? EmployeeId { get; set; }
        }
    }
}
