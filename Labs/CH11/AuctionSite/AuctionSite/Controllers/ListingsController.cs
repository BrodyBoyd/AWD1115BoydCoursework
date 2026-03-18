using AuctionSite.Data;
using Microsoft.AspNetCore.Mvc;

namespace AuctionSite.Controllers
{
    public class ListingsController(ApplicationDbContext context) : Controller
    {
        public IActionResult Index()
        {
            var listings = context.Listings.ToList();
            return View(listings);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
