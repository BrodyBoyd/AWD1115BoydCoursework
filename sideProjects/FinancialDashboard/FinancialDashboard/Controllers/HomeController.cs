using FinancialDashboard.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinancialDashboard.Controllers
{
    public class HomeController(ApplicationDbContext context) : Controller
    {
        Random random = new Random();
        public decimal CalculateEarnings(Investment investment, int luck)
        {
            var volatility = investment.EarningMethod.Volatility;
            int randomNumber = random.Next(101);
            decimal percentEarned = 0;
            var percentBeforeChange = investment.EarningMethod.PercentageReturn;
            if (volatility == 0)
            {
                percentEarned = (percentBeforeChange / 12);
            }
            if (volatility == 1)
            {
                if (randomNumber > 90)
                {
                    percentBeforeChange *= 1.03m;
                }
                if (randomNumber < 10 && randomNumber > 1)
                {
                    percentBeforeChange *= 0.98m;
                }
                if (randomNumber == 1)
                {
                    percentBeforeChange *= -.05m;
                }
                percentEarned  = (percentBeforeChange / 12);
            }
            if (volatility == 1.5m)
            {
                if (randomNumber > 85)
                {
                    percentBeforeChange *= 1.1m;
                }
                if (randomNumber < 10 && randomNumber >= 5)
                {
                    percentBeforeChange *= 0.95m;
                }
                if (randomNumber < 5)
                {
                    percentBeforeChange *= -.09m;
                }
                percentEarned = (percentBeforeChange / 12);
            }
            if (volatility == 3)
            {
                if (randomNumber > 92)
                {
                    percentBeforeChange *= 1.4m;
                }
                if (randomNumber > 80 && randomNumber <= 92)
                {
                    percentBeforeChange *= 1.1m;
                }
                if (randomNumber < 28 && randomNumber >= 12)
                {
                    percentBeforeChange *= 0.93m;
                }
                if (randomNumber < 12 && randomNumber > 4)
                {
                    percentBeforeChange *= -.86m;
                }
                if (randomNumber <= 4)
                {
                    percentBeforeChange *= -1.4m;
                }
                percentEarned = (percentBeforeChange / 12);
            }
            if (volatility == 4)
            {
                if (randomNumber >= 90)
                {
                    percentBeforeChange *= 1.4m;
                }
                if (randomNumber > 75 && randomNumber < 90)
                {
                    percentBeforeChange *= 1.1m;
                }
                if (randomNumber < 35 && randomNumber >= 18)
                {
                    percentBeforeChange *= 0.84m;
                }
                if (randomNumber < 18 && randomNumber > 7)
                {
                    percentBeforeChange *= -1;
                }
                if (randomNumber <= 7)
                {
                    percentBeforeChange *= -1.4m;
                }
                percentEarned = (percentBeforeChange / 12);
            }
            if (volatility == 5)
            {
                if (randomNumber == 97 || randomNumber == 98 || randomNumber == 100)
                {
                    percentBeforeChange *= 1.5m;
                }
                if (randomNumber == 99)
                {
                    percentBeforeChange *= 5;
                }
                if (randomNumber < 97 && randomNumber >= 12)
                {
                    percentBeforeChange *= -1.1m;
                }
                if (randomNumber < 12 && randomNumber >= 3)
                {
                    percentBeforeChange *= -1.8m;
                }
                if (randomNumber > 0 && randomNumber < 3)
                {
                    percentBeforeChange *= -5m;
                }
                if (luck == 1)
                {
                    percentEarned = -(percentBeforeChange / 12);
                }
                percentEarned = (percentBeforeChange / 12);

            }
            if (volatility == 7)
            {
                if (randomNumber == 97 || randomNumber == 98 || randomNumber == 100)
                {
                    percentBeforeChange *= 3;
                }
                if (randomNumber == 99)
                {
                    percentBeforeChange *= 7;
                }
                if (randomNumber < 97 && randomNumber >= 55)
                {
                    percentBeforeChange *= 1.04m;
                }
                if (randomNumber < 55 && randomNumber >= 33)
                {
                    percentBeforeChange *= -.8m;
                }
                if (randomNumber < 33 && randomNumber >= 12)
                {
                    percentBeforeChange *= -1.3m;
                }
                if (randomNumber > 0 && randomNumber < 12)
                {
                    percentBeforeChange *= -5m;
                }
                percentEarned = (percentBeforeChange / 12);

            }

            var amountEarned = investment.InvestmentValue * percentEarned;
            return amountEarned;
        }

        public async Task<IActionResult> ProgressMonth(string? UserId, int months = 1, int? years = 0)
        {
            int luck = random.Next(5);

            if (years > 0)
            {
                months = Convert.ToInt32(years * 12);
            }

            var user = context.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();

            //for (int i = 0; i < months; i++)
            //{
                
            //}
            

            for (int i = 0; i < months; i++)
            {
                if (user.YearlyIncome > 0)
                {
                    user.Balance += ((user.YearlyIncome / 12) * 0.15m);
                }
                context.Users.Update(user);
                await context.SaveChangesAsync();
                foreach (var investment in context.Investments.Where(l => l.UserId == UserId).Where(l => l.InvestmentValue > 0).Include(i => i.EarningMethod).ToList())
                {
                    if ((user.Balance - investment.MonthlyContribution) > 0)
                    {
                        investment.InvestmentAmount += Convert.ToDecimal(investment.MonthlyContribution);
                        investment.InvestmentValue += Convert.ToDecimal(investment.MonthlyContribution);
                        user.Balance -= Convert.ToDecimal(investment.MonthlyContribution);
                    }

                    investment.InvestmentValue += CalculateEarnings(investment, luck);
                    investment.InvestmentLengthInMonths += 1;

                    double totalMonths = (double)investment.InvestmentLengthInMonths;
                    double yearsElapsed = totalMonths / 12.0;
                    decimal cumulativeInflation = (decimal)Math.Pow(1.024, yearsElapsed);
                    investment.ValueInInitialYear = investment.InvestmentValue / cumulativeInflation;

                    context.Investments.Update(investment);
                    context.Users.Update(user);
                    context.SaveChanges();
                }

                decimal investmentValue = await context.Investments.Where(l => l.UserId == UserId).SumAsync(l => l.InvestmentValue);
                decimal balanceForSnapshot = await context.Users.Where(u => u.UserName == User.Identity.Name).Select(u => u.Balance).FirstOrDefaultAsync();
                decimal portfolioValue =  investmentValue + balanceForSnapshot;


                context.InvestmentSnapshots.Add(new InvestmentSnapshot
                {
                    UserId = UserId,
                    TotalPortfolioValue = portfolioValue,
                    MonthNumber = user.TimeProgressedInMonths
                });

                user.TimeProgressedInMonths += 1;
                context.Users.Update(user);
                context.SaveChanges();
            }

            decimal balance = context.Users.Where(u => u.UserName == User.Identity.Name).Select(u => u.Balance).FirstOrDefault();
            ViewBag.Balance = balance;

            return RedirectToAction("Investments", "Home");
        }

        public IActionResult Index()
        {
            var viewModel = new HomeViewModel
            {
                EarningMethods = context.EarningMethods.ToList(),
                Investments = context.Investments.ToList()
            };
            ViewBag.Balance = context.Users.Where(u => u.UserName == User.Identity.Name).Select(u => u.Balance).FirstOrDefault();
            return View(viewModel);
        }

        public IActionResult PlaceInvestment()
        {
            ViewBag.EarningMethods = context.EarningMethods.ToList();
            ViewBag.Balance = context.Users.Where(u => u.UserName == User.Identity.Name).Select(u => u.Balance).FirstOrDefault();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PLaceInvestment(Investment investment)
        {
            ViewBag.EarningMethods = context.EarningMethods.ToList();
            ViewBag.Balance = context.Users.Where(u => u.UserName == User.Identity.Name).Select(u => u.Balance).FirstOrDefault();

            var user = context.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();

            if (investment.MonthlyContribution == null)
            {
                investment.MonthlyContribution = 0;
            }
            investment.ValueInInitialYear = investment.InvestmentAmount;
            if (user.Balance - investment.InvestmentAmount < 0)
            {
                ModelState.AddModelError("InvestmentAmount", "You do not have enough balance to make this investment.");
                return View(investment);
            }
            if (ModelState.IsValid)
            {
                
                user.AmountInvested += investment.InvestmentAmount;
                user.Balance -= investment.InvestmentAmount;
                investment.InvestmentValue = investment.InvestmentAmount;
                context.Investments.Add(investment);
                await context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(investment);

        }

        public IActionResult Deposit()
        {
            ViewBag.Balance = context.Users.Where(u => u.UserName == User.Identity.Name).Select(u => u.Balance).FirstOrDefault();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Deposit(decimal amount)
        {
            ViewBag.Balance = context.Users.Where(u => u.UserName == User.Identity.Name).Select(u => u.Balance).FirstOrDefault();

            var user = context.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            if (user != null)
            {
                user.Balance += amount;
                context.Users.Update(user);
                await context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Investments()
        {
            var viewModel = new InvestmentsViewModel
            {
                EarningMethods = context.EarningMethods.ToList(),
                Investments = context.Investments.Where(i => i.UserId == context.Users.Where(u => u.UserName == User.Identity.Name).Select(u => u.Id).FirstOrDefault()).ToList()
            };
            ViewBag.Balance = context.Users.Where(u => u.UserName == User.Identity.Name).Select(u => u.Balance).FirstOrDefault();

            return View(viewModel);
        }

        public IActionResult WithdrawInvestment(int id)
        {
            decimal Balance = context.Users.Where(u => u.UserName == User.Identity.Name).Select(u => u.Balance).FirstOrDefault();
            ViewBag.Balance = Balance;
            var investment = context.Investments
                .Include(i => i.EarningMethod)
                .FirstOrDefault(i => i.InvestmentId == id);

            if (investment == null)
                return NotFound();

            return View(investment);

        }

        [HttpPost]
        public async Task<IActionResult> WithdrawInvestment(int id, decimal withdrawAmount)
        {
            var investment = context.Investments.Where(i => i.InvestmentId == id).FirstOrDefault();

            if (investment == null || (investment.InvestmentValue < withdrawAmount))
            {
                return View(investment);
            }
            investment.InvestmentValue -= withdrawAmount;
            if ((investment.InvestmentAmount - withdrawAmount) < 0)
            {
                investment.InvestmentAmount = 0;
            }
            else
            {
                investment.InvestmentAmount -= withdrawAmount;
            }

            var user = context.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            if (user != null)
            {
                user.Balance += withdrawAmount;
            }
            user.AmountWithdrawn += withdrawAmount;
            context.SaveChanges();
            return RedirectToAction("Investments", "Home");
        }

        public async Task<IActionResult> ProfilePage()
        {
            decimal Balance = context.Users.Where(u => u.UserName == User.Identity.Name).Select(u => u.Balance).FirstOrDefault();
            ViewBag.Balance = Balance;
            var user = context.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            if (user == null) return RedirectToAction("Index");

            var investments = await context.Investments
                .Include(i => i.EarningMethod)
                .Where(i => i.UserId == user.Id)
                .ToListAsync();

            var active = investments.Where(i => i.InvestmentValue > 0).ToList();

            decimal totalInvested = active.Sum(i => i.InvestmentAmount);
            decimal totalValue = active.Sum(i => i.InvestmentValue);
            decimal totalProfit = totalValue - totalInvested;

            decimal weightedReturn = 0;
            if (totalInvested > 0)
            {
                weightedReturn = active.Sum(i =>
                    i.InvestmentAmount * (i.EarningMethod.PercentageReturn * 100)
                ) / totalInvested;
            }

            var mostProfitable = active
                .OrderByDescending(i => i.InvestmentValue - i.InvestmentAmount)
                .FirstOrDefault();

            double yearsProgressed = user.TimeProgressedInMonths / 12;

            var vm = new ProfileViewModel
            {
                UserName = user.UserName,
                YearsProgressed = yearsProgressed,
                Email = user.Email,
                Balance = user.Balance,
                YearlyIncome = user.YearlyIncome,
                AmountInvested = user.AmountInvested,
                AmountWithdrawn = user.AmountWithdrawn,
                TotalPortfolioValue = totalValue,
                TotalProfit = totalProfit,
                WeightedAvgReturn = weightedReturn,
                ActiveInvestmentCount = active.Count,
                MostProfitableInvestment = mostProfitable,
                ActiveInvestments = active
            };
            var snapshots = await context.InvestmentSnapshots
                .Where(s => s.UserId == user.Id)
                .OrderBy(s => s.MonthNumber)
                .ToListAsync();

            vm.MonthlyPortfolioValues = snapshots.Select(s => s.TotalPortfolioValue).ToList();
            vm.MonthLabels = snapshots.Select(s => $"Month {s.MonthNumber}").ToList();


            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateIncome(decimal yearlyIncome)
        {
            decimal Balance = context.Users.Where(u => u.UserName == User.Identity.Name).Select(u => u.Balance).FirstOrDefault();
            ViewBag.Balance = Balance;
            var user = context.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            if (user == null) return RedirectToAction("Index");

            user.YearlyIncome = yearlyIncome;
            context.Users.Update(user);
            await context.SaveChangesAsync();

            return RedirectToAction("ProfilePage");
        }

        public IActionResult IncreaseInvestment(int id)
        {
            decimal Balance = context.Users.Where(u => u.UserName == User.Identity.Name).Select(u => u.Balance).FirstOrDefault();
            ViewBag.Balance = Balance;
            var investment = context.Investments
                .Include(i => i.EarningMethod)
                .FirstOrDefault(i => i.InvestmentId == id);

            if (investment == null)
                return NotFound();

            return View(investment);

        }

        [HttpPost]
        public async Task<IActionResult> IncreaseInvestment(int id, decimal increaseAmount)
        {
            var investment = context.Investments.Where(i => i.InvestmentId == id).FirstOrDefault();
            var user = context.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();

            if (investment == null || (user.Balance < increaseAmount))
            {
                return View(investment);
            }
            investment.InvestmentValue += increaseAmount; 
            investment.InvestmentAmount += increaseAmount;
            

            if (user != null)
            {
                user.Balance -= increaseAmount;
            }
            user.AmountInvested += increaseAmount;
            context.SaveChanges();
            return RedirectToAction("Investments", "Home");
        }

        public IActionResult ResetAccount()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ConfirmReset()
        {
            var user = context.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            var usersInvestments = context.Investments.Where(i => i.UserId == user.Id).ToList();
            var usersSnapshots = context.InvestmentSnapshots.Where(i => i.UserId == user.Id).ToList();

            foreach (var investment in  usersInvestments)
            {
                context.Investments.Remove(investment);
            }

            foreach (var snapshot in usersSnapshots)
            {
                context.InvestmentSnapshots.Remove(snapshot);
            }

            user.AmountInvested = 0;
            user.Balance = 0;
            user.AmountWithdrawn = 0;
            user.TimeProgressedInMonths = 0;
            user.YearlyIncome = 0;
            context.SaveChanges();
            return RedirectToAction("ProfilePage", "Home");
        }

    }
}
