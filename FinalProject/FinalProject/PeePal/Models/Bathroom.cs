namespace PeePal.Models
{
    public class Bathroom
    {
        public int BathroomId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Review> Reviews { get; set; } = new();

    }
}
