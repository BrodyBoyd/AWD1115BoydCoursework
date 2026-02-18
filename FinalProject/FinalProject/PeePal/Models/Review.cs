using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace PeePal.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        
        public int Smell { get; set; }
        public int Cleanliness { get; set; }
        public int Privacy { get; set; }
        public int Comfort { get; set; }
        public int Availability { get; set; }
        public string Likes { get; set; }
        public string Dislikes { get; set; }
        public string Notes { get; set; }
        public DateTime DateSubmitted { get; set; } = DateTime.Today;
        

        [ValidateNever]
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

        // Link to the Bathroom this review is about
        public int? BathroomId { get; set; }

        [ValidateNever]
        public Bathroom Bathroom { get; set; }

        public double getAverageScore()
        {
            double total = Smell + Cleanliness + Privacy + Comfort + Availability;
            return total / 5;
        }

        

        public double AverageScore
        {
            get { return getAverageScore(); }
        }
    }
}
