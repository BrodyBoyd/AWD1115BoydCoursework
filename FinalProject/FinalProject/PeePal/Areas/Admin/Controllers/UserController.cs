using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PeePal.Areas.Admin.Models;
using PeePal.Models;
namespace PeePal.Areas.Admin.Controllers
{

    [Authorize]
    [Area("Admin")]
    [Route("[controller]/[action]/{id?}/{slug?}")]
    //[Authorize(Roles = "Admin")]

    public class UserController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<ApplicationUser> users = new List<ApplicationUser>();

            foreach (ApplicationUser user in userManager.Users)
            {
                user.RoleNames = await userManager.GetRolesAsync(user);
                users.Add(user);
            }

            UserViewModel model = new UserViewModel
            {
                Users = users,
                Roles = roleManager.Roles
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdminRole()
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            await roleManager.DeleteAsync(role);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddToAdmin(string id)
        {
            IdentityRole adminRole = await roleManager.FindByNameAsync("Admin");
            if (adminRole == null)
            {
                TempData["message"] = "Admin role dosent't exist.";
            }
            else
            {
                ApplicationUser user = await userManager.FindByIdAsync(id);
                await userManager.AddToRoleAsync(user, adminRole.Name);
            }
            return RedirectToAction("Index");

        }


        [HttpPost]
        public async Task<IActionResult> RemoveFromAdmin(string id)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);
            await userManager.RemoveFromRoleAsync(user, "Admin");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (!result.Succeeded)
                {
                    string errorMessage = "";
                    foreach (IdentityError error in result.Errors)
                    {
                        errorMessage += error.Description + " | ";
                    }
                    TempData["message"] = errorMessage;
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult Dashboard()
        {
            var totalBathrooms = context.Bathrooms.Count();
            var totalReviews = context.Reviews.Count();

            // Popular ZIP Codes (Top 5)
            var popularZipCodes = context.Bathrooms
                .Where(b => b.Reviews.Any())
                .Select(b => new
                {
                    b.Zip,
                    ReviewCount = b.Reviews.Count()
                })
                .GroupBy(x => x.Zip)
                .Select(g => new ZipCodeStats
                {
                    ZipCode = g.Key,
                    ReviewCount = g.Sum(x => x.ReviewCount)
                })
                .OrderByDescending(z => z.ReviewCount)
                .Take(5)
                .ToList();

            // Most Active Reviewer
            var mostActiveReviewer = context.Reviews
                .GroupBy(r => r.User.UserName)
                .Select(g => new ReviewerStats
                {
                    UserName = g.Key,
                    ReviewCount = g.Count()
                })
                .OrderByDescending(r => r.ReviewCount)
                .FirstOrDefault();

            // Reviews per month (last 6 months)
            var sixMonthsAgo = DateTime.UtcNow.AddMonths(-5);
            var reviewsByMonth = context.Reviews
                .Where(r => r.DateSubmitted >= sixMonthsAgo)
                .GroupBy(r => new { r.DateSubmitted.Year, r.DateSubmitted.Month })
                .Select(g => new
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    Count = g.Count()
                })
                .OrderBy(x => x.Year).ThenBy(x => x.Month)
                .ToList();

            var monthLabels = reviewsByMonth
                .Select(x => new DateTime(x.Year, x.Month, 1).ToString("MMM yyyy"))
                .ToList();

            var monthCounts = reviewsByMonth
                .Select(x => x.Count)
                .ToList();

            var vm = new AdminDashboardViewModel
            {
                TotalUsers = userManager.Users.Count(),
                TotalBathrooms = totalBathrooms,
                TotalReviews = totalReviews,
                AverageReviewsPerBathroom = totalBathrooms > 0
                    ? (double)totalReviews / totalBathrooms
                    : 0,
                PopularZipCodes = popularZipCodes,
                MostActiveReviewer = mostActiveReviewer,
                ReviewMonths = monthLabels,
                ReviewCountsByMonth = monthCounts,
                PopularZipLabels = popularZipCodes.Select(z => z.ZipCode).ToList(),
                PopularZipReviewCounts = popularZipCodes.Select(z => z.ReviewCount).ToList()
            };

            return View(vm);
        }

    }
}
