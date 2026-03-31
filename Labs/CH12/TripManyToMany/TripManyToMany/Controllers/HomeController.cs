using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TripManyToMany.Data;
using TripManyToMany.Models;

namespace TripManyToMany.Controllers
{
    public class HomeController(TripsContext _context) : Controller
    {
        private readonly TripsContext context = _context;
        public IActionResult Index()
        {
            var trips = context.Trips.Include(t => t.Activities).Include(t => t.Destination).Include(t => t.Accommodation).ToList();

            return View(trips);
        }

        public IActionResult Destinations()
        {
            var destinations = context.Destinations.ToList();
            return View(destinations);
        }

        public IActionResult AddDestination()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDestination(Destination destination)
        {
            if (ModelState.IsValid)
            {
                context.Destinations.Add(destination);
                context.SaveChanges();
                return RedirectToAction("Destinations");
            }
            return View(destination);
        }
        public IActionResult AddAccommodation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAccommodation(Accommodation accommodation)
        {
            if (ModelState.IsValid)
            {
                context.Accommodations.Add(accommodation);
                context.SaveChanges();
                return RedirectToAction("Accommodations");
            }
            return View(accommodation);
        }
        public IActionResult AddActivity()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddActivity(Activity activity)
        {
            if (ModelState.IsValid)
            {
                context.Activities.Add(activity);
                context.SaveChanges();
                return RedirectToAction("Activities");
            }
            return View(activity);

        }

        public IActionResult Accommodations()
        {
            var accommodations = context.Accommodations.ToList();
            return View(accommodations);
        }
        public IActionResult Activities()
        {
            var activities = context.Activities.ToList();
            return View(activities);
        }

        public IActionResult AddTrip()
        {
            var accommodations = context.Accommodations.Select(a => new SelectListItem { Value = a.AccommodationId.ToString(), Text = a.Name }).ToList();
            var destinations = context.Destinations.Select(d => new SelectListItem { Value = d.DestinationId.ToString(), Text = d.DestinationName }).ToList();
            var Activities = context.Activities.Select(a => new SelectListItem { Value = a.ActivityId.ToString(), Text = a.Name }).ToList();

            ViewBag.Accommodations = accommodations;
            ViewBag.Destinations = destinations;
            ViewBag.Activities = Activities;

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> AddTrip(TripViewModel model)
        {
            var accommodations = context.Accommodations.Select(a => new SelectListItem { Value = a.AccommodationId.ToString(), Text = a.Name }).ToList();
            var destinations = context.Destinations.Select(d => new SelectListItem { Value = d.DestinationId.ToString(), Text = d.DestinationName }).ToList();
            var Activities = context.Activities.Select(a => new SelectListItem { Value = a.ActivityId.ToString(), Text = a.Name }).ToList();

            ViewBag.Accommodations = accommodations;
            ViewBag.Destinations = destinations;
            ViewBag.Activities = Activities;

            if (!ModelState.IsValid)
            {
                return View(model);

            }

            var trip = new Trip
            {
                DestinationId = model.DestinationId,
                AccommodationId = model.AccommodationId,
                StartDate = model.StartDate,
                EndDate = model.EndDate
            };
            var selectedActivities = context.Activities
                .Where(a => model.SelectedActivityIds.Contains(a.ActivityId))
                .ToList();

            trip.Activities = selectedActivities;

            context.Trips.Add(trip);
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult DeleteTrip(int id)
        {
            var trip = context.Trips.Where(t => t.TripId == id).Include(t => t.Destination).FirstOrDefault();
            var destination = trip.Destination.DestinationName;
            ViewBag.DestinationName = destination;

            return View(trip);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDeleteTrip(int id)
        {

            var trip = context.Trips.Where(t => t.TripId == id).Include(t => t.Destination).FirstOrDefault();
            if (trip != null)
            {
                context.Trips.Remove(trip);
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteAccommodation(int id)
        {
            var Accommodation = context.Accommodations.Where(a => a.AccommodationId == id).FirstOrDefault();
            var accommodation = Accommodation.Name;
            ViewBag.AccommodationName = accommodation;

            return View(Accommodation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDeleteAccommodation(int id)
        {

            var trips = context.Trips.Where(t => t.AccommodationId == id).FirstOrDefault();
            if (trips == null)
            {
                var Accommodation = context.Accommodations.Where(a => a.AccommodationId == id).FirstOrDefault();
                context.Accommodations.Remove(Accommodation);
            }

            if (trips != null)
            {
                TempData["Message"] = "Can not delete as this is associated with a trip";
            }
            await context.SaveChangesAsync();
            return RedirectToAction("Accommodations");
        }
        public IActionResult DeleteDestination(int id)
        {
            var destination = context.Destinations.Where(d => d.DestinationId == id).FirstOrDefault();
            var destinationName = destination.DestinationName;
            ViewBag.destinationName = destinationName;

            return View(destination);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDeleteDestination(int id)
        {

            var trips = context.Trips.Where(t => t.DestinationId == id).FirstOrDefault();
            if (trips == null)
            {
                var destination = context.Destinations.Where(d => d.DestinationId == id).FirstOrDefault();
                context.Destinations.Remove(destination);
            }

            if (trips != null)
            {
                TempData["Message"] = "Can not delete as this is associated with a trip";
            }
            await context.SaveChangesAsync();
            return RedirectToAction("Destinations");
        }
        public IActionResult DeleteActivity(int id)
        {
            var activity = context.Activities.Where(a => a.ActivityId == id).FirstOrDefault();
            var ActivityName = activity.Name;
            ViewBag.ActivityName = ActivityName;

            return View(activity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDeleteActivity(int id)
        {

            var activity = context.Activities.Where(a => a.ActivityId == id).FirstOrDefault();
            if (activity != null)
            {
                context.Activities.Remove(activity);
            }
            await context.SaveChangesAsync();
            return RedirectToAction("Activities");
        }
    }
}
