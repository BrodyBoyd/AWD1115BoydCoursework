using FluentValidation;
using HOT4.Models;

namespace HOT4.Validators
{
    public class CustomerValidation : AbstractValidator<Customer>
    {
        private readonly AppointmentContext _context;

        public CustomerValidation(AppointmentContext context)
        {
            _context = context;
            RuleFor(a => a.Username)
                .NotEmpty().WithMessage("A Username is required.");
            RuleFor(a => a.PhoneNumber)
                .Matches(@"^[0-9]{10}$").WithMessage("Must be 10 numbers in this format: 1234567890")
                .NotEmpty().WithMessage("A Phone Number is required.");

        }

    }
}
