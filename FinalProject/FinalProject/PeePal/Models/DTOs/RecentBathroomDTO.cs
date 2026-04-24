namespace PeePal.Models.DTOs
{
    public class RecentBathroomDTO
    {
        public int BathroomId { get; set; }
        public string? Name { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public string? Slug { get; set; }
    }
}
