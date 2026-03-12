using FluentValidation;
using Lab11.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Lab11.Validators
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        private readonly ApplicationDbContext _context;
        public EmployeeValidator(ApplicationDbContext context)
        {
            _context = context;

            RuleFor(e => e.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.");
            RuleFor(e => e.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.");
            RuleFor(e => e.Birthday)
                .LessThan(DateTime.Now).WithMessage("Birthday must be in the past.");
            RuleFor(e => e.HireDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Hire date cannot be in the future.")
                .GreaterThanOrEqualTo(e => e.Birthday).GreaterThanOrEqualTo(new DateTime(1995, 1, 1)).WithMessage("Hire date cannot be before birthday.");

            RuleFor(p => p.FirstName).MustAsync(async (employee, firstName, cancellation) =>
            {
                var exists = await _context.Employees.AnyAsync(e => e.FirstName == firstName && e.LastName == employee.LastName && e.Birthday == employee.Birthday, cancellation);
                return !exists;
            }).WithMessage("An employee with the same name and birthday already exists.");
        }
    }
}
