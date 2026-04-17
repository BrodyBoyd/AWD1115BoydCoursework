using HOT3.Models;
using Microsoft.AspNetCore.Identity;

namespace HOT3.Areas.Admin.Models
{
    public class UserViewModel
    {
        public IEnumerable<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
        public IEnumerable<IdentityRole> Roles { get; set; } = new List<IdentityRole>();
    }
}
