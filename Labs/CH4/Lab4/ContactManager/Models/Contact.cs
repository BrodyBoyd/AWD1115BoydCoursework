using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactManager.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        
        [Required(ErrorMessage = "Please enter a First Name")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Please enter a Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter a Phone Number")]
        public string PhoneNumber { get; set; }
        
        [Required(ErrorMessage = "Please enter an Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Select a Category")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a valid Category")]
        public int CategoryId { get; set; }

        [ValidateNever]
        public Category? Category { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;

        [NotMapped]
        public string Slug => $"{FirstName?.ToLower()}-{LastName?.ToLower()}";

        //[ValidateNever]
        //public virtual Category? Category { get; set; }
    }
}
