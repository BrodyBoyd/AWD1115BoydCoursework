using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FinancialDashboard.Models
{
    public class InvestmentsViewModel
    {
        public List<EarningMethod> EarningMethods { get; set; } = new List<EarningMethod>();
        public List<Investment> Investments { get; set; } = new List<Investment>();
        public int Months { get; set; }
        public int Years { get; set; }
        [Required]
        public string? UserId { get; set; }
        public IdentityUser? User { get; set; }
    }
}
