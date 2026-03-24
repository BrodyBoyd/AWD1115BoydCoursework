using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace FinancialDashboard.Models
{
    public class Investment
    {
        public int InvestmentId { get; set; }
        public decimal InvestmentAmount { get; set; }
        public decimal InvestmentValue { get; set; }
        public int InvestmentLengthInYears { get; set; } = 0;


        [ValidateNever]
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

        public int? EMId { get; set; }

        [ValidateNever]
        public EarningMethod EarningMethod { get; set; }
        public int? EarningMethodId { get; set; }
    }
}
