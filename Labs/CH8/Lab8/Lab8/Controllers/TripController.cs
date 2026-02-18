using Lab8.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab8.Controllers
{
    public class TripController : Controller
    {
        private readonly TripsContext _context;

        public TripController(TripsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Add(string? id)
        {
            var vm = new TripViewModel();
            switch (id)
            {
                case "1":
                    vm.PageNumber = 1;
                    return View("Page1", vm);
                case "2":
                    vm.PageNumber = 2;
                    return View("Page2", vm);
                case "3":
                    return View("Page3");
                default:
                    return View("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult Add(TripViewModel vm)
        {
            if (vm.PageNumber == 1)
            {
                if (!ModelState.IsValid)
                {
                    TempData["Destination"] = vm.Trip.Destination;
                    TempData["Accommodation"] = vm.Trip.Accommodation;
                    TempData["StartDate"] = vm.Trip.StartDate;
                    TempData["EndDate"] = vm.Trip.EndDate;
                    return RedirectToAction("Add", new { id = "2" });
                }
                else
                {
                    return View("Page1", vm);
                }
                
            } else if (vm.PageNumber == 2)
            {
                TempData["AccommodationEmail"] = vm.Trip.AccommodationEmail;
                TempData["AccommodationPhone"] = vm.Trip.AccommodationPhone;
                return RedirectToAction("Add", new { id = "3" });
            } else
            {
                Trip trip = new()
                {
                    Destination = TempData["Destination"].ToString(),
                    Accommodation = TempData["Accommodation"].ToString(),
                    StartDate = (System.DateTime)TempData["StartDate"],
                    EndDate = (System.DateTime)TempData["EndDate"],
                    AccommodationEmail = TempData["AccommodationEmail"].ToString(),
                    AccommodationPhone = TempData["AccommodationPhone"].ToString(),
                    Activity1 = vm.Trip.Activity1,
                    Activity2 = vm.Trip.Activity2,
                    Activity3 = vm.Trip.Activity3
                };
                _context.Trips.Add(trip);
                _context.SaveChanges();
            }
            return RedirectToAction("Index","Home");
        }

    }
}
