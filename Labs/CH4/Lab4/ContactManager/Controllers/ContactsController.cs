using ContactManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ContactManager.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ContactContext _context;

        public ContactsController(ContactContext contactContext)
        {
            _context = contactContext;
        }

        public async Task<IActionResult> Index()
        {
            // Eager-load Category so the view can read contact.Category.CategoryName
            var contacts = await _context.Contacts
                .Include(c => c.Category)
                .ToListAsync();

            return View(contacts);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }

            // Fix: filter by ContactId and include Category
            var contact = await _context.Contacts
                .Include(c => c.Category)
                .FirstOrDefaultAsync(c => c.ContactId == id);

            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }
            var contact = await _context.Contacts
                .FirstOrDefaultAsync(c => c.ContactId == id);
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
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
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
                return View(new Contact() { DateAdded = today });
            }
            else
            {
                return View(await _context.Contacts.FindAsync(id));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEdit(Contact c)
        {
            if (ModelState.IsValid)
            {
                if (c.ContactId == 0)
                {
                    _context.Contacts.Add(c);
                }
                else
                {
                    _context.Contacts.Update(c);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(c);
        }
    }
}
