using System.ComponentModel.DataAnnotations;

namespace TripManyToMany.Models
{
    public class Accommodation
    {
        public int AccommodationId { get; set; }

        [Required]
        public string Name { get; set; }
        public int? Phone {  get; set; }
        public string? Email { get; set; }

        public List<Trip> Trips { get; set; } = new();
    }
}
