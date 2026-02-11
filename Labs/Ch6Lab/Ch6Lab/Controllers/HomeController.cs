using Microsoft.AspNetCore.Mvc;
using Ch6Lab.Models;
using Microsoft.EntityFrameworkCore;
namespace Ch6Lab.Controllers
{
    public class HomeController : Controller
    {
        private readonly FaqsContext _context;
        public HomeController(FaqsContext faqsContext)
        {
            _context = faqsContext;
        }

        [Route("topic/{topic}/category/{category}")]
        [Route("topic/{topic}")]
        [Route("category/{category}")]
        [Route("/")]
        public IActionResult Index(string topic, string category)
        {
            var faqs = _context.FAQs.Include(f => f.Category)
                .Include(f => f.Topic)
                .OrderBy(f => f.Question)
                .ToList();
            ViewBag.Topics = _context.Topics.OrderBy(t => t.Name).ToList();
            ViewBag.Categories = _context.Categories.OrderBy(t => t.Name).ToList();
            ViewBag.SelectedTopic = topic;

            if (!string.IsNullOrEmpty(topic)) 
            {
                faqs = faqs.Where(f => f.Topic.TopicId == topic).ToList();
            }
            
            if (!string.IsNullOrEmpty(category))
            {
                faqs = faqs.Where(f => f.Category.CategoryId == category).ToList();
            }

            return View(faqs);
        }
    }
}
