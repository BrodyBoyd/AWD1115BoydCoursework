using System.ComponentModel.DataAnnotations;

namespace TripManyToMany.Models
{
    public class Destination
    {
        public int DestinationId { get; set; }

        [Required(ErrorMessage = "Destination Name is required.")]
        public string DestinationName { get; set; }
        public List<Trip> Trips { get; set; } = new();

    }
}
