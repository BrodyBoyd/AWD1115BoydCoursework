namespace TripManyToMany.Models
{
    public class TripViewModel
    {
        public int DestinationId { get; set; }
        public int AccommodationId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<int> SelectedActivityIds { get; set; } = new();

    }
}
