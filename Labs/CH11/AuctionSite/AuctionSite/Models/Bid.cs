using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AuctionSite.Models
{
    public class Bid
    {
        public int BidId { get; set; }
        public double Price { get; set; }

        [Required]
        public string? UserId { get; set; }
        public IdentityUser? User { get; set; }

        public int? ListingId { get; set; }
        public Listing? Listing { get; set; }
    }
}
