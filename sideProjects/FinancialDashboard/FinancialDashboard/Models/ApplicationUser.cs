using Microsoft.AspNetCore.Identity;

namespace FinancialDashboard.Models
{
    public class ApplicationUser : IdentityUser
    {
        public decimal Balance { get; set; }
        public decimal AmountWithdrawn { get; set; }
        public decimal AmountInvested { get; set; }
        public decimal YearlyIncome { get; set; }
        public int TimeProgressedInMonths { get; set; }
    }
}
