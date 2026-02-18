using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace PeePal.Models
{
    public class Bathroom
    {
        public int BathroomId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Name { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public List<Review> Reviews { get; set; } = new();

        [NotMapped]
        public string Slug
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Name))
                    return string.Empty;

                // normalize
                var slug = Name.ToLowerInvariant().Trim();

                // replace whitespace with hyphens
                slug = Regex.Replace(slug, @"\s+", "-");

                // remove invalid chars (keep a-z, 0-9 and hyphen)
                slug = Regex.Replace(slug, @"[^a-z0-9\-]", string.Empty);

                // collapse multiple hyphens and trim hyphens
                slug = Regex.Replace(slug, @"-+", "-").Trim('-');

                return slug;
            }
        }

    }
}
