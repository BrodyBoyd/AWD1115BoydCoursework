using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HOT2.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please enter a Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter an image Url")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Please Select a Price")]
        [Range(1, 100000, ErrorMessage = "Please enter a valid Price")]
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        [NotMapped]
        public string Slug => $"{Name?.ToLower()}";
        [Required(ErrorMessage = "Please Select a Category")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a valid Category")]
        public int CategoryId { get; set; }

        [ValidateNever]
        public Category? Category { get; set; }

    }
}
