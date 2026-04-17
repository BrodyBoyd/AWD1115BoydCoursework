using Microsoft.AspNetCore.Identity;
using PeePal.Models;

namespace PeePal.Areas.Admin.Models
{
    public class UserViewModel
    {
        public IEnumerable<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
        public IEnumerable<IdentityRole> Roles { get; set; } = new List<IdentityRole>();
    }
}
