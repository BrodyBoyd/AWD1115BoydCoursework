using PeePal.Models;
using FluentValidation;
namespace PeePal.Validation
{
    public class ReviewValidator : AbstractValidator<Review>
    {
        public ReviewValidator(ApplicationDbContext context)
        {
            RuleFor(r => r.Smell).NotNull().WithMessage("Must Select a Value").InclusiveBetween(1, 5).WithMessage("Smell rating must be between 1 and 5.");
            RuleFor(r => r.Cleanliness).NotNull().WithMessage("Must Select a Value").InclusiveBetween(1, 5).WithMessage("Cleanliness rating must be between 1 and 5.");
            RuleFor(r => r.Availability).NotNull().WithMessage("Must Select a Value").InclusiveBetween(1, 5).WithMessage("Availability rating must be between 1 and 5.");
            RuleFor(r => r.Comfort).NotNull().WithMessage("Must Select a Value").InclusiveBetween(1, 5).WithMessage("Comfort rating must be between 1 and 5.");
            RuleFor(r => r.Privacy).NotNull().WithMessage("Must Select a Value").InclusiveBetween(1, 5).WithMessage("Privacy rating must be between 1 and 5.");
            RuleFor(r => r.Likes)
                .NotEmpty().WithMessage("Likes cannot be empty.")
                .MaximumLength(500).WithMessage("Likes cannot exceed 500 characters.");
            RuleFor(r => r.Dislikes)
                .NotEmpty().WithMessage("Dislikes cannot be empty.")
                .MaximumLength(500).WithMessage("Likes cannot exceed 500 characters.");
            RuleFor(r => r.Notes)
                .NotEmpty().WithMessage("Notes cannot be empty.")
                .MaximumLength(500).WithMessage("Likes cannot exceed 500 characters.");

        }
    }
}
