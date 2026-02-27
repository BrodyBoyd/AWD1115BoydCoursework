using System.ComponentModel.DataAnnotations;

namespace ShoppingCartLab.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        [StringLength(100)] 
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        //Navigation property
        public List<Product> Products { get; set; } = new(); 

    }
}
