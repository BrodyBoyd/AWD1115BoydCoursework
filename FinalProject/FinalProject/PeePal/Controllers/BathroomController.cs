using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeePal.Models;

namespace PeePal.Controllers
{
    public class FavoriteRequest
    {
        public int BathroomId { get; set; }
        public string UserId { get; set; }
    }

    public class BathroomController(ApplicationDbContext context) : Controller
    {
        public IActionResult Index(int BathroomId)
        {
            var bathroom = context.Bathrooms.Where(b => b.BathroomId == BathroomId)
                .Include(b => b.Reviews)
                    .ThenInclude(r => r.User)
                .Include(b => b.FavoritedBy)
                .FirstOrDefault(b => b.BathroomId == BathroomId);
            return View(bathroom);
        }

        public IActionResult EditFavoritedBy(int Id)
        {
            var bathroom = context.Bathrooms.Where(b => b.BathroomId == Id)
                .Include(b => b.FavoritedBy)
                .FirstOrDefault(b => b.BathroomId == Id);
            var users = context.Users.ToList();
            ViewBag.Users = users;
            return View(bathroom);
        }

        [HttpPost]
        //[Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Favorite([FromBody] FavoriteRequest request)
        {
            var bathroom = await context.Bathrooms
                .Include(b => b.FavoritedBy)
                .FirstOrDefaultAsync(b => b.BathroomId == request.BathroomId);

            if (bathroom == null) return NotFound();

            var user = await context.Users.FindAsync(request.UserId);

            if (user == null) return NotFound();

            if (!bathroom.FavoritedBy.Any(u => u.Id == request.UserId))
            {
                bathroom.FavoritedBy.Add(user);
                await context.SaveChangesAsync();
            }

            return Ok();
        }

        [HttpPost]
        //[Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Unfavorite([FromBody] FavoriteRequest request)
        {
            var bathroom = await context.Bathrooms
                .Include(b => b.FavoritedBy)
                .FirstOrDefaultAsync(b => b.BathroomId == request.BathroomId);

            if (bathroom == null) return NotFound();

            var user = bathroom.FavoritedBy.FirstOrDefault(u => u.Id == request.UserId);

            if (user != null)
            {
                bathroom.FavoritedBy.Remove(user);
                await context.SaveChangesAsync();
            }

            return Ok();
        }

    }
}
