using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AuctionSite.Models
{
    public class Listing
    {
        public int ListingId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public bool AuctionEnded { get; set; } = false;
        public string Category { get; set; }

        [Required]
        public string? UserId { get; set; }
        public IdentityUser? User { get; set; }

        public List<Bid>? Bids { get; set; }
        public List<Comment>? Comments { get; set; }


        public enum CategoryName
        {
            Watch,
            Necklace,
            Braclet,
            Other
        }
    }
}
