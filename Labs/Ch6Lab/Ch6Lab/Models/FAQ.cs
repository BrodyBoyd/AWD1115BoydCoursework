using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Ch6Lab.Models
{
    public class FAQ
    {
        public int FAQId { get; set; }
        public string Question { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
        public string CategoryId { get; set; } = string.Empty;
        public Category Category { get; set; } = null!;
        public string TopicId { get; set; } = string.Empty;
        public Topic Topic { get; set; } = null!;
    }
}
