using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PeePal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PeePal.Areas.Reviews.Controllers
{
    [Authorize]
    [Area("Reviews")]
    [Route("[controller]/[action]/{id?}/{slug?}")]
    public class ReviewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reviews

        public async Task<IActionResult> Index()
        {
            // Load bathrooms with their reviews and the users who wrote those reviews
            var bathrooms = await _context.Bathrooms
                .Include(b => b.Reviews)
                    .ThenInclude(r => r.User)
                .ToListAsync();

            return View(bathrooms);
        }

        // GET: Reviews/Details/5/{slug}
        public async Task<IActionResult> Details(int? id, string slug)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews
                .Include(r => r.User)
                .Include(r => r.Bathroom)
                .FirstOrDefaultAsync(m => m.ReviewId == id);
            if (review == null)
            {
                return NotFound();
            }
            // Note: bathrooms are stored in the Bathrooms table; reviews reference those records.
            // Slug handling removed because Review does not expose a Slug property.
            return View(review);
        }

        // GET: Reviews/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["BathroomId"] = new SelectList(_context.Bathrooms, "BathroomId", "Name");
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            Review newReview = new Review
            {

                UserId = userId,
                DateSubmitted = DateTime.Today

            };
            return View(newReview);
        }


        public async Task<LatLng> GeocodeAddress(string address)
        {
            var apiKey = "X-UsA7HE5BsPx2kLv8UAs3iPHzK54NQP3nlQvmnxunY";
            var url = $"https://geocode.search.hereapi.com/v1/geocode?q={Uri.EscapeDataString(address)}&apiKey={apiKey}";

            using var client = new HttpClient();
            var response = await client.GetStringAsync(url);

            dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject(response);

            double lat = json.items[0].position.lat;
            double lng = json.items[0].position.lng;

            return new LatLng { Lat = lat, Lng = lng };
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("UserId,ReviewId,BathroomId,Smell,Cleanliness,Privacy,Comfort,Availability,Likes,Dislikes,Notes,DateSubmitted")] Review review,
            string NewBathroomName,
            string NewBathroomStreet,
            string NewBathroomCity,
            string NewBathroomState,
            string NewBathroomZip)
        {
            review.DateSubmitted = DateTime.Today;
            // ensure the review is associated with the currently logged in user
            review.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (ModelState.IsValid)
            {
                // If the user did not pick an existing bathroom, create a new Bathroom
                // from the provided address fields and associate it with the review.
                if (review.BathroomId == null || review.BathroomId == 0)
                {
                    // require at least a name and street to create a bathroom
                    if (!string.IsNullOrWhiteSpace(NewBathroomName) && !string.IsNullOrWhiteSpace(NewBathroomStreet))
                    {
                        var bathroom = new Bathroom
                        {
                            Name = NewBathroomName.Trim(),
                            Street = NewBathroomStreet.Trim(),
                            City = NewBathroomCity?.Trim() ?? string.Empty,
                            State = NewBathroomState?.Trim() ?? string.Empty,
                            Zip = NewBathroomZip?.Trim() ?? string.Empty
                        };

                        // try to geocode the address if provided
                        try
                        {
                            var address = $"{bathroom.Street}, {bathroom.City}, {bathroom.State} {bathroom.Zip}";
                            var coords = await GeocodeAddress(address);
                            bathroom.Latitude = coords.Lat;
                            bathroom.Longitude = coords.Lng;
                        }
                        catch
                        {
                            // Geocoding failures should not block creating the bathroom; leave coords null
                        }

                        _context.Bathrooms.Add(bathroom);
                        await _context.SaveChangesAsync();

                        review.BathroomId = bathroom.BathroomId;
                    }
                }

                _context.Add(review);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", review.UserId);
            ViewData["BathroomId"] = new SelectList(_context.Bathrooms, "BathroomId", "Name", review.BathroomId);
            return View(review);
        }

        // GET: Reviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews
                .Include(r => r.Bathroom)
                .FirstOrDefaultAsync(m => m.ReviewId == id);
            var bathrooms = await _context.Bathrooms.ToListAsync();
            if (review == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", review.UserId);
            ViewData["BathroomId"] = new SelectList(bathrooms, "BathroomId", "Name", review.BathroomId);
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReviewId,Smell,Cleanliness,Privacy,Comfort,Availability,Likes,Dislikes,Notes,DateSubmitted,UserId")] Review review)
        {
            if (id != review.ReviewId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(review);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewExists(review.ReviewId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", review.UserId);
            return View(review);
        }

        // GET: Reviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.ReviewId == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review != null)
            {
                _context.Reviews.Remove(review);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReviewExists(int id)
        {
            return _context.Reviews.Any(e => e.ReviewId == id);
        }
    }
}
