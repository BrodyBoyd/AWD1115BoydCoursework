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
            var results = _context.Reviews.ToList();


            return View(results);
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
        public IActionResult SearchByZip(string zip)
        {
            if (string.IsNullOrWhiteSpace(zip))
                return PartialView("_SearchResults", Enumerable.Empty<Review>());

            var results = _context.Reviews
                .Where(r => r.Zip == zip)
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
