using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace TripManyToMany.Models
{
    public class Trip
    {
        public int TripId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [ValidateNever]
        public Destination Destination { get; set; }
        public int? DestinationId { get; set; }

        [ValidateNever]
        public Accommodation Accommodation { get; set; }
        public int? AccommodationId { get; set; }

        public ICollection<Activity> Activities { get; set; } 


    }
}
