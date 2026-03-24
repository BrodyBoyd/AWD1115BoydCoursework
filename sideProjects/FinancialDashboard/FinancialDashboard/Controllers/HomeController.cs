using FinancialDashboard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinancialDashboard.Controllers
{
    public class HomeController(ApplicationDbContext context) : Controller
    {
        public void ProgressYear(string? UserId)
        {
            if (UserId != null)
            {
                foreach (var investment in context.Investments.Where(l => l.UserId == UserId).Include(i => i.EarningMethod).ToList())
                {
                    investment.InvestmentValue += earningMethod.CalculateEarnings(investment.InvestmentAmount, investment.InvestmentLengthInYears);
                    context.Investments.Update(investment);
                    context.SaveChanges();
                }
            }
            
            //var investment = context.Investments.Where(i => i.InvestmentId == InvestmentId)
            //    .Include(i => i.EarningMethod)
            //    .FirstOrDefault();
            //var earningMethod = context.EarningMethods.Where(e => e.EarningMethodId == EarningMethodId).FirstOrDefault();



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
            var viewModel = new PlaceInvestmentViewModel
            {
                EarningMethods = context.EarningMethods.ToList()
            };
            return View(viewModel);
        }

        public IActionResult Deposit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Deposit(decimal amount)
        {
            var user = context.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            if (user != null)
            {
                user.Balance += amount;
                context.Users.Update(user);
                await context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
