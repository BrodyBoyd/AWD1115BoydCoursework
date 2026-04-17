using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PeePal.Models;
using System.Threading.Tasks;

namespace PeePal.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel(UserManager<ApplicationUser> userManager, ApplicationDbContext context) : PageModel
    {

        public string Username { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string FullName { get; set; }
        public List<Bathroom> FavoriteBathrooms { get; set; } = new();

        public async Task OnGetAsync()
        {
            var user = await userManager.GetUserAsync(User);
            var userWithFavorites = await context.Users
                .Include(u => u.Favorites)
                .FirstOrDefaultAsync(u => u.Id == user.Id);

            if (user != null)
            {
                Username = user.ProfileUsername ?? user.UserName;
                Email = user.Email;
                EmailConfirmed = user.EmailConfirmed;
                FullName = user.FullName ?? string.Empty;
                FavoriteBathrooms = userWithFavorites?.Favorites ?? new List<Bathroom>();
            }
        }
    }
}
