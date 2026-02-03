using HOT2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HOT2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductContext _context;

        public HomeController(ProductContext productContext)
        {
            _context = productContext;
        }

        public async Task<IActionResult> Index()
        {
            // Include Category so navigation property is populated for the view
            var products = await _context.Products
                .Include(p => p.Category)
                .ToListAsync();

            return View(products);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            // Fix: filter by ContactId and include Category
            var product = await _context.Products
                .Include(c => c.Category)
                .FirstOrDefaultAsync(p => p.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }
            var contact = await _context.Products
                .FirstOrDefaultAsync(p => p.ProductId == id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> AddEdit(int id = 0)
        {
            if (id == 0)
            {
                DateTime today = DateTime.Today;
                return View(new Product());
            }
            else
            {
                return View(await _context.Products.FindAsync(id));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEdit(Product p)
        {
            if (ModelState.IsValid)
            {
                if (p.ProductId == 0)
                {
                    _context.Products.Add(p);
                }
                else
                {
                    _context.Products.Update(p);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(p);
        }
    }
}
