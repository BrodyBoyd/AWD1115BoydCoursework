using FluentValidation;
using AuctionSite.Models;
using AuctionSite.Data;
namespace AuctionSite.Validators
{
    public class BidValidator : AbstractValidator<Bid>
    {
        public BidValidator(ApplicationDbContext context)
        {
            RuleFor(b => b.Price)
                .Must((bid, price) =>
                {
                    var listing = context.Listings.Find(bid.ListingId);
                    return listing == null || price > listing.Price;
                }).WithMessage(bid =>
                {
                    var listing = context.Listings.Find(bid.ListingId);
                    return $"Bid must be greater than the current price of ${listing?.Price}";
                });

            RuleFor(b => b)
                .Must(bid => !context.Bids.Any(existing =>
                    existing.ListingId == bid.ListingId &&
                    existing.UserId == bid.UserId &&
                    existing.Price == bid.Price)).WithMessage("You have already places this exact bid");
        }
    }
}
