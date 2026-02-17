using System.ComponentModel.DataAnnotations;

namespace Lab8.Models
{
    public class Trip
    {
        public int TripId { get; set; }

        [Required(ErrorMessage = "Destination is required.")]
        public string Destination { get; set; }
        public string Accommodation { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.MinValue;
        public string AccommodationPhone { get; set; }
        public string AccommodationEmail { get; set; }
        public string Activity1 { get; set; }
        public string Activity2 { get; set; }
        public string Activity3 { get; set; }
    }
}
