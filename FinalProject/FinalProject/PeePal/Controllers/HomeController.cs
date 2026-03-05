using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeePal.Models;

namespace PeePal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "Home Page";
            var reviews = _context.Reviews
                .Include(r => r.Bathroom)
                .Include(r => r.User)
                .ToList();

            // Also include bathrooms so the view model is populated
            var bathrooms = _context.Bathrooms.ToList();

            var model = new ReviewsViewModel
            {
                Reviews = reviews,
                Bathrooms = bathrooms
            };

            return View(model);
        }

        [Route("Contact")]
        public IActionResult Contact()
        {
            ViewBag.Title = "Contact";
            return View();
        }

        [Route("About")]
        public IActionResult About()
        {
            ViewBag.Title = "About";
            return View();
        }

        public IActionResult RateRestroom()
        {
            ViewBag.Title = "Rate a Restroom";
            return View();
        }
        public IActionResult FrontendDetails()
        {
            ViewBag.Title = "Rate a Restroom";
            return View();
        }

        [HttpGet]
        public IActionResult SearchByZip(string zip, int page = 1)
        {
            int pageSize = 6;

            if (string.IsNullOrWhiteSpace(zip))
                return PartialView("_SearchResults", Enumerable.Empty<Review>());

            // Normalize input before counting
            zip = zip.Trim();

            int totalCount = _context.Reviews
                .Include(r => r.Bathroom)
                .Where(r => r.Bathroom != null && r.Bathroom.Zip == zip)
                .Count();

            int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            // If there are no results, totalPages should be 0 (handled by view)
            ViewBag.TotalPages = totalPages;

            // Validate requested page bounds
            int searchPage = page;
            if (searchPage < 1) searchPage = 1;
            if (totalPages > 0 && searchPage > totalPages) searchPage = totalPages;

            ViewBag.CurrentPage = searchPage;

            // Filter reviews by the associated Bathroom's Zip and eager-load related data
            var results = _context.Reviews
                .Include(r => r.Bathroom)
                .Include(r => r.User)
                .Where(r => r.Bathroom != null && r.Bathroom.Zip == zip)
                .Skip((searchPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            


            return PartialView("_SearchResults", results);
        }
        public async Task<LatLng> GeocodeAddress(string address)
        {

            var apiKey = "YOUR_HERE_API_KEY";
            var url = $"https://geocode.search.hereapi.com/v1/geocode?q={Uri.EscapeDataString(address)}&apiKey={apiKey}";

            using var client = new HttpClient();
            var response = await client.GetStringAsync(url);

            dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject(response);

            double lat = json.items[0].position.lat;
            double lng = json.items[0].position.lng;

            return new LatLng { Lat = lat, Lng = lng };
        }
    }
}
