using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace lab2.Models
{
    public class PriceQuotationCalculator
    {
        [Required(ErrorMessage = "Please enter a subtotal")]
        [Range(0, int.MaxValue, ErrorMessage="Please Enter a valid positive number for subtotal")]
        public double? Subtotal { get; set; }

        [Required(ErrorMessage = "Please enter a discount percentage")]
        [Range(0, 100, ErrorMessage = "Please Enter a valid positive number for discount % between 1-100")]

        public double? DiscountPercent { get; set; }

        public double GetDiscountTotal()
        {
            double DiscountedTotal = Convert.ToDouble(Subtotal * (DiscountPercent / 100));
            return DiscountedTotal;
             
        }
        public double CalculatePrice()
        {
            double DiscountedTotal = Convert.ToDouble(Subtotal * (DiscountPercent / 100));
            double DiscountTotal = Convert.ToDouble(Subtotal - DiscountedTotal);
            return DiscountTotal;

        }
    }
}
