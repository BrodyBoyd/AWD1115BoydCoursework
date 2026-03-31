namespace FinancialDashboard.Models
{
    public class ProfileViewModel
    {
        public string UserName { get; set; }
        public double YearsProgressed { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }
        public decimal YearlyIncome { get; set; }
        public decimal AmountInvested { get; set; }
        public decimal AmountWithdrawn { get; set; }
        public decimal TotalPortfolioValue { get; set; }
        public decimal TotalProfit { get; set; }
        public decimal WeightedAvgReturn { get; set; }
        public int ActiveInvestmentCount { get; set; }
        public Investment MostProfitableInvestment { get; set; }
        public List<Investment> ActiveInvestments { get; set; }

        public List<decimal> MonthlyPortfolioValues { get; set; } = new();
        public List<string> MonthLabels { get; set; } = new();
    }
}
