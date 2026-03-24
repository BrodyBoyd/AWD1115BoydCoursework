using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinancialDashboard.Models
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<EarningMethod> EarningMethods { get; set; }
        public DbSet<Investment> Investments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EarningMethod>().HasData(
                new EarningMethod
                {
                    EarningMethodId = 1,
                    Name = "High-Yield-Savings",
                    PercentageReturn = .043m,
                    Volatility = 0
                },
                new EarningMethod
                {
                    EarningMethodId = 2,
                    Name = "Safe-Investments",
                    PercentageReturn = .055m,
                    Volatility = 1
                },
                new EarningMethod
                {
                    EarningMethodId = 3,
                    Name = "Index-Funds",
                    PercentageReturn = .098m,
                    Volatility = 1.5m
                }, new EarningMethod
                {
                    EarningMethodId = 4,
                    Name = "Individual-Stocks",
                    PercentageReturn = .11m,
                    Volatility = 3
                }, new EarningMethod
                {
                    EarningMethodId = 5,
                    Name = "Day-Trading",
                    PercentageReturn = .12m,
                    Volatility = 5
                }, new EarningMethod
                {
                    EarningMethodId = 6,
                    Name = "Sports-Betting",
                    PercentageReturn = .078m,
                    Volatility = 5
                }, new EarningMethod
                {
                    EarningMethodId = 7,
                    Name = "Collecting",
                    PercentageReturn = .09m,
                    Volatility = 4
                }, new EarningMethod
                {
                    EarningMethodId = 8,
                    Name = "Crypto",
                    PercentageReturn = .35m,
                    Volatility = 7
                }, new EarningMethod
                {
                    EarningMethodId = 9,
                    Name = "RealEstate",
                    PercentageReturn = .108m,
                    Volatility = 1.5m
                });
        }
    }
}
