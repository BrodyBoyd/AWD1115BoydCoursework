using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HOT3.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Today;

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        [StringLength(500)]
        public string ShippingAddress { get; set; }

        [ValidateNever]
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

        [ValidateNever]
        public List<OrderItem> OrderItems { get; set; } = new();
    }
}
