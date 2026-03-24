namespace FinancialDashboard.Models
{
    public class PlaceInvestmentViewModel
    {
        public List<EarningMethod> EarningMethods { get; set; }
        public string SelectedMethod { get; set; }
        public decimal Amount { get; set; }

    }
}
