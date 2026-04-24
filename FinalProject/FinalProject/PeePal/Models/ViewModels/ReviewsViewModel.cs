namespace PeePal.Models.ViewModels
{
    public class ReviewsViewModel
    {
        public List<Bathroom> Bathrooms { get; set; } = new();
        public List<Review> Reviews { get; set; } = new();
    }
}
