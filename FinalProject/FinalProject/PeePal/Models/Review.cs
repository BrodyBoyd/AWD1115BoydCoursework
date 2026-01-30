using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PeePal.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string address { get; set; }
        public string name { get; set; }
        public int Smell { get; set; }
        public int Cleanliness { get; set; }
        public int Privacy { get; set; }
        public int Comfort { get; set; }
        public int Availability { get; set; }
        public string Likes { get; set; }
        public string Dislikes { get; set; }
        public string Tips { get; set; }
        public string Notes { get; set; }
        public DateTime DateSubmitted { get; set; } = DateTime.Today;

        [ValidateNever]
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }


    }
}
