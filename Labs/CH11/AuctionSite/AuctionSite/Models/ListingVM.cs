using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static AuctionSite.Models.Listing;

namespace AuctionSite.Models
{
    public class ListingVM
    {
        public int ListingId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public IFormFile ImageUrl { get; set; }
        public bool AuctionEnded { get; set; } = false;
        public CategoryName Category { get; set; }

        [Required]
        public string? UserId { get; set; }
        public IdentityUser? User { get; set; }

        public enum CategoryName
        {
            Watch,
            Necklace,
            Braclet,
            Other
        }

    }
}
