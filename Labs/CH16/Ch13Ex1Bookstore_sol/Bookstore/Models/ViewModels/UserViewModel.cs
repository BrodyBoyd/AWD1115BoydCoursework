using Bookstore.Models.DomainModels;
using Microsoft.AspNetCore.Identity;

namespace Bookstore.Models.ViewModels
{
    public class UserViewModel
    {
        public IEnumerable<User> Users { get; set; } = new List<User>();
        public IEnumerable<IdentityRole> Roles { get; set; } = new List<IdentityRole>();
    }
}
