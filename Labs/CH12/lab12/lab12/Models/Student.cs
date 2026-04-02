namespace lab12.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string? FinancialAidStatus { get; set; }

        public List<Course> Courses { get; set; } = new();
    }
}
