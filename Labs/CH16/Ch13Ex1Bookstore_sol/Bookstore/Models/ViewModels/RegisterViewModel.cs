using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please endter a UserName")]
        [StringLength(255)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please endter a Password")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword", ErrorMessage = "Passwords do not match")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please endter a Confirm Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Conrim Password")]
        public string ConfirmPassword { get; set; }
    }
}
