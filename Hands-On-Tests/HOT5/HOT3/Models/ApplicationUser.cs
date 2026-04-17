using Microsoft.AspNetCore.Identity;

namespace HOT5.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Order> Orders { get; set; } = new();
    }
}
