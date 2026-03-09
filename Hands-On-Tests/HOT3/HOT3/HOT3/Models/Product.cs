using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace HOT3.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        [StringLength(100)]
        public string StockQuantity { get; set; }


        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }


        [Required]
        [StringLength(500)]
        public string? ImageUrl { get; set; }

        public int CategoryId { get; set; }

        [ValidateNever]
        public Category Category { get; set; }

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
