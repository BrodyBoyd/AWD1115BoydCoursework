using System.Threading;
using HOT4.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace HOT4.Validators
{
    public class AppointmentValidator : AbstractValidator<Appointment>
    {
        private readonly AppointmentContext _context;
        private bool BeOnTheHour(DateTime date)
        {
            return date.Minute == 0 && date.Second == 0;
        }

        public AppointmentValidator(AppointmentContext context)
        {
            _context = context;
            RuleFor(a => a.StartDate)
                .NotEmpty().WithMessage("Start date is required.")
                .GreaterThan(DateTime.Now).WithMessage("Start date must be in the future.")
                .Must(BeOnTheHour).WithMessage("Start date must be on the hour (e.g., 1:00, 2:00, 3:00).");
            RuleFor(a => a.Summary)
                .NotEmpty().WithMessage("Summary is required.");
            RuleFor(a => a.CustomerId)
                .NotEmpty().WithMessage("Must Select  a Customer.")
                .MustAsync(async (int customerId, CancellationToken cancellation) =>
                {
                    var customer = await _context.Customers.FindAsync(customerId, cancellation);
                    return customer != null;
                }).WithMessage("Customer ID does not exist.");
            RuleFor(a => a)
                .MustAsync(async (appointment, cancellation) =>
                {
                    var overlappingAppointment = await _context.Appointments
                        .AnyAsync(a => a.StartDate == appointment.StartDate, cancellation);
                    return !overlappingAppointment;
                }).WithMessage("An appointment already exists at this time.");
        }

    }
}
