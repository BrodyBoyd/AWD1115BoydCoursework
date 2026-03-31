namespace FinancialDashboard.Models
{
    public class InvestmentSnapshot
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public decimal TotalPortfolioValue { get; set; }
        public int MonthNumber { get; set; }
    }
}
