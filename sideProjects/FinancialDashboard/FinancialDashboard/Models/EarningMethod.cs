namespace FinancialDashboard.Models
{
    public class EarningMethod
    {
        
        public int EarningMethodId { get; set; }
        public string Name { get; set; }
        public decimal PercentageReturn { get; set; }
        public decimal? Volatility { get; set; }
    }
}
