using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HOT5.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        public int OrderId { get; set; }
        public int ProductId { get; set; }

        [ValidateNever]
        public Order Order { get; set; } = null!;

        [ValidateNever]
        public Product Product { get; set; } = null!;

        [NotMapped]
        public decimal TotalPrice => Quantity * UnitPrice;
    }
}
