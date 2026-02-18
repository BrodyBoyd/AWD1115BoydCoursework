using System.ComponentModel.DataAnnotations;

namespace Lab8.Models
{
    public class Trip
    {
        public int TripId { get; set; }

        [Required(ErrorMessage = "Destination is required.")]
        public string? Destination { get; set; }

        [Required(ErrorMessage = "Accommodation is required.")]
        public string? Accommodation { get; set; }

        [Required(ErrorMessage = "Start Date is required.")]
        public DateTime? StartDate { get; set; } 

        [Required(ErrorMessage = "End Date is required.")]
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
        public string? AccommodationPhone { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        public string? AccommodationEmail { get; set; }

        [Required(ErrorMessage = "Activity 1 is required.")]
        public string? Activity1 { get; set; }

        [Required(ErrorMessage = "Activity 2 is required.")]
        public string? Activity2 { get; set; }

        [Required(ErrorMessage = "Activity 3 is required.")]
        public string? Activity3 { get; set; }
    }
}
