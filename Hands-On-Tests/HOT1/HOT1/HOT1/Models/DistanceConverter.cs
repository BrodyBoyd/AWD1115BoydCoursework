using System.ComponentModel.DataAnnotations;

namespace HOT1.Models
{
    public class DistanceConverter
    {
        [Required(ErrorMessage = "Please enter an inch value")]
        [Range(0, int.MaxValue, ErrorMessage = "Please Enter a valid positive number for inches")]
        public double Inches { get; set; }

        public double GetCm()
        {
            double cm = Inches * 2.54;
            return cm;
        }


    }
}
