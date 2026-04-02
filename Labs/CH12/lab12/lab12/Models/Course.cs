using System.ComponentModel.DataAnnotations;

namespace lab12.Models
{
    public class Course
    {
        
        public int CourseId { get; set; }

        [Required]
        public string Title { get; set; }

        public List<Student> Students { get; set; } = new();
    }
}
