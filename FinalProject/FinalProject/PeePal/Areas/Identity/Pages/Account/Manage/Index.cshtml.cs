using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PeePal.Models;

namespace PeePal.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public string Username { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string FullName { get; set; }

        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                Username = user.ProfileUsername ?? user.UserName;
                Email = user.Email;
                EmailConfirmed = user.EmailConfirmed;
                FullName = user.FullName ?? string.Empty;
            }
        }
    }
}
