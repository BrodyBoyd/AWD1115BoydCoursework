using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HOT4.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Summary { get; set; }
        public DateTime StartDate { get; set; }
        public int CustomerId { get; set; }

        [ValidateNever]
        public Customer customer { get; set; }
    }
}
