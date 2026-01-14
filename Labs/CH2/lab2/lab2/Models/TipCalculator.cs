using System.ComponentModel.DataAnnotations;

namespace lab2.Models
{
    public class TipCalculator
    {
        [Required(ErrorMessage = "Please enter a subtotal")]
        [Range(1, int.MaxValue, ErrorMessage = "Please Enter a valid positive number for cost")]
        public double? Cost { get; set; }

        public double getFifteen()
        {
            double FifteenTip = Convert.ToDouble(Cost * .15);
            return FifteenTip;
        }
        public double getTwenty()
        {
            double TwentyTip = Convert.ToDouble(Cost * .20);
            return TwentyTip;
        }
        public double getTwentyFive()
        {
            double TwentyFiveTip = Convert.ToDouble(Cost * .25);
            return TwentyFiveTip;
        }
    }
}
