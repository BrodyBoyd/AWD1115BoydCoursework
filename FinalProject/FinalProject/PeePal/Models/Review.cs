using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace PeePal.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string name { get; set; }
        public int Smell { get; set; }
        public int Cleanliness { get; set; }
        public int Privacy { get; set; }
        public int Comfort { get; set; }
        public int Availability { get; set; }
        public string Likes { get; set; }
        public string Dislikes { get; set; }
        public string Notes { get; set; }
        public DateTime DateSubmitted { get; set; } = DateTime.Today;
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        [ValidateNever]
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

        public double getAverageScore()
        {
            double total = Smell + Cleanliness + Privacy + Comfort + Availability;
            return total / 5;
        }

        [NotMapped]
        public string Slug
        {
            get
            {
                if (string.IsNullOrWhiteSpace(name))
                    return string.Empty;

                // normalize
                var slug = name.ToLowerInvariant().Trim();

                // replace whitespace with hyphens
                slug = Regex.Replace(slug, @"\s+", "-");

                // remove invalid chars (keep a-z, 0-9 and hyphen)
                slug = Regex.Replace(slug, @"[^a-z0-9\-]", string.Empty);

                // collapse multiple hyphens and trim hyphens
                slug = Regex.Replace(slug, @"-+", "-").Trim('-');

                return slug;
            }
        }

        public double AverageScore
        {
            get { return getAverageScore(); }
        }
    }
}
