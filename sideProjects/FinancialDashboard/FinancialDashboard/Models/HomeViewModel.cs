namespace FinancialDashboard.Models
{
    public class HomeViewModel
    {
        public List<EarningMethod> EarningMethods { get; set; } = new List<EarningMethod>();
        public List<Investment> Investments { get; set; } = new List<Investment>();
    }
}
