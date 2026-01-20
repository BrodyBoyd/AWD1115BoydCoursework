using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace HOT1.Models
{
    public class OrderForm
    {
        [Required(ErrorMessage = "Please enter an Quantity")]
        [Range(0, int.MaxValue, ErrorMessage = "Please Enter a valid positive number for Quantity")]
        public double Quantity { get; set; }

        public string? DiscountCode { get; set; }
        public double DiscountAmount { get; set; }


        public string CheckCode()
        {
            if (DiscountCode == "6175")
            {
                DiscountAmount = .3;
                return "30% Discount Applied!";
            }
            else if (DiscountCode == "1390")
            {
                DiscountAmount = .2;
                return "20% Discount Applied!";
            }
            else if (DiscountCode == "BB88")
            {
                DiscountAmount = .1;
                return "10% Discount Applied!";
            }
            else if (!string.IsNullOrWhiteSpace(DiscountCode))
            {
                DiscountAmount = 0;
                return "* Invalid Discount Code";
            }
            else
            {
                DiscountAmount = 0;
                return "";
            } 
        }
        public string GetOrder()
        {
            double PricePerShirt;
            double Subtotal;
            double Tax;
            double Total;
            if (DiscountAmount == 0)
            {
                 PricePerShirt = 15;
                 Subtotal = Quantity * PricePerShirt;
                 Tax = Subtotal * .08;
                 Total = Subtotal + Tax;
            }
            else
            {
                 double DiscountTotal = 15 * DiscountAmount;
                 PricePerShirt = 15 - DiscountTotal;
                 Subtotal = Quantity * PricePerShirt;
                 Tax = Subtotal * .08;
                 Total = Subtotal + Tax;
            }
            

            return @$"{Quantity} T-Shirts at ${PricePerShirt} each
---------------------------

Subtotal ${Subtotal}
Tax ${Tax}
Total ${Total}";
            
        }

    }
}
