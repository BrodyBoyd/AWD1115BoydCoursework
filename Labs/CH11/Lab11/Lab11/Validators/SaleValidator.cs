using FluentValidation;
using Lab11.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab11.Validators
{
    public class SaleValidator : AbstractValidator<Sales>
    {
        private readonly ApplicationDbContext _context;
        public SaleValidator(ApplicationDbContext context)
        {
            _context = context;

            RuleFor(s => s.Quarter).NotEmpty().WithMessage("Quarter is Required.").InclusiveBetween(1, 4).WithMessage("Quarter must be between 1 and 4.");
            RuleFor(s => s.Year).NotEmpty().WithMessage("Year is Required.").InclusiveBetween(2000, DateTime.Now.Year).WithMessage($"Year must be between 2000 and {DateTime.Now.Year}.");
            RuleFor(s => s.Amount).NotEmpty().WithMessage("Amount is Required.").GreaterThan(0).WithMessage("Amount must be greater than 0.");
            RuleFor(s => s).MustAsync(async (sale, cancellation) =>
            {
                var exists = await _context.Sales.AnyAsync(x =>
                    x.Quarter == sale.Quarter &&
                    x.Year == sale.Year &&
                    x.EmployeeId == sale.EmployeeId &&
                    x.SalesId != sale.SalesId,
                    cancellation);

                return !exists;
            }).WithMessage("A sale for the same quarter, year, and employee already exists.");
        }
    }
}
