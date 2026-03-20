using AuctionSite.Data;
using AuctionSite.Models;
using AuctionSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AuctionSite.Controllers
{
    public class ListingsController(IWebHostEnvironment _webHostEnvironment, IListingsService _listingsService, IBidsService _bidsService) : Controller
    {
        private const int PageSize = 3;
        public async Task<IActionResult> Index(string? search, int page = 1, string sortby = "title", string category = "All")
        {
            ViewBag.Categories = new List<string> { "All", "Watch", "Necklace", "Bracelet", "Other"};
            ViewBag.CurrentCategory = category;
            ViewBag.CurrentPage = page;
            var query = _listingsService.GetAll();

            if (!string.IsNullOrEmpty(category) && category.ToLower() != "all")
            {
                query = query.Where(l => l.Category.ToLower() == category.ToLower());
            }

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(l => l.Title.Contains(search) || l.Description.Contains(search));
            }
            query = sortby.ToLower() switch
            {
                "title" => query.OrderBy(l => l.Title),
                "description" => query.OrderBy(l => l.Description),
                "price" => query.OrderBy(l => l.Price),
                _ => query.OrderBy(l => l.Title)
            };

            var totalItems = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)PageSize);
            ViewBag.TotalPages = totalPages;
            var listings = await query
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();

            return View(listings);
        }

        public async Task<IActionResult> MyAuctions(string? userId)
        {
            var listings = await _listingsService.GetAll().Where(l => l.UserId == userId).ToListAsync();
            return View(listings);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ListingVM listing)
        {
            if (listing.Image != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                string fileName = listing.Image.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    listing.Image.CopyTo(fileStream);
                }

                var listObj = new Listing
                {
                    Title = listing.Title,
                    Description = listing.Description,
                    Price = listing.Price,
                    ImageUrl = fileName,
                    AuctionEnded = listing.AuctionEnded,
                    Category = listing.Category,
                    UserId = listing.UserId
                };
                await _listingsService.Add(listObj);
                return RedirectToAction("Index");
            }
            return View(listing);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var listing = await _listingsService.GetById(id);
            if (listing == null)
            {
                return NotFound();
            }
            return View(listing);
        }

        [HttpPost]
        public async Task<ActionResult> AddBid([Bind("Price, ListingId, UserId")] Bid bid)
        {
            if (ModelState.IsValid)
            {
                await _bidsService.AddBid(bid);
            }
            var listing = await _listingsService.GetById(bid.ListingId);
            listing.Price = bid.Price;
            await _listingsService.SaveChanges();

            return View("Details", listing);
        }

        public async Task<IActionResult> EndAuction(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var listing = await _listingsService.GetById(id);
            if (listing == null)
            {
                return NotFound();
            }
            listing.AuctionEnded = true;
            await _listingsService.SaveChanges();
            return View("Details", listing);
        }

        public async Task<IActionResult> MyBids()
        {
            var myBids = _bidsService.GetAll()
                .Include(b => b.User)
                .Where(l => l.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier))
                .AsNoTracking();
            return View(await myBids.ToListAsync());
        }
    }
}