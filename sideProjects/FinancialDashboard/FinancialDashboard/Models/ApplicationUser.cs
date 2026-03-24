using Microsoft.AspNetCore.Identity;

namespace FinancialDashboard.Models
{
    public class ApplicationUser : IdentityUser
    {
        public decimal Balance { get; set; }
    }
}
