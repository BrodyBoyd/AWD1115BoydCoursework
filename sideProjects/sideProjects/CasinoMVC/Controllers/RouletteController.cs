using CasinoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Text.Json;

namespace CasinoMVC.Controllers
{
    public class RouletteController : Controller
    {
        public IActionResult Index()
        {
            var model = new RoulettePlayer(); // or whatever your class is
            return View(model);

        }
    }
}
