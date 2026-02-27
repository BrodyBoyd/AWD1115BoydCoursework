using Microsoft.AspNetCore.Identity;

namespace ShoppingCartLab.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Order> Orders { get; set; } = new(); //Creates a one-to-many relationship between ApplicationUser and Order
        
    }
}
