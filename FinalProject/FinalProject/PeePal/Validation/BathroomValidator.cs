using FluentValidation;
using PeePal.Models;
using System.Data;

namespace PeePal.Validation
{
    public class BathroomValidator : AbstractValidator<Bathroom>
    {
        public BathroomValidator(ApplicationDbContext context)
        {
            RuleFor(b => b)
                .Must(bathroom => !context.Bathrooms.Any(b => b.Longitude == bathroom.Longitude && b.Latitude == bathroom.Latitude))
                .WithMessage("This Bathroom Already exists, please select it from the dropdown.");
        }
    }
}
