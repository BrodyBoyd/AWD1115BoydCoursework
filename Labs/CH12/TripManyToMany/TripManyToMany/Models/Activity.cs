using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace TripManyToMany.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }

        [Required(ErrorMessage = "Activity Name is required.")]
        public string Name { get; set; }

        [ValidateNever]
        public ICollection<Trip> Trips { get; set; }
    }
}
