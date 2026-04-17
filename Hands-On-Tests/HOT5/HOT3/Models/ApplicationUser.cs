using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace HOT3.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public List<Order> Orders { get; set; } = new();

        [NotMapped]
        public IList<string> RoleNames { get; set; } = new List<string>();
    }
}
