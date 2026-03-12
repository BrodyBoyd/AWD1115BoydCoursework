using Microsoft.EntityFrameworkCore.Metadata;

namespace Lab11.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime HireDate { get; set; }
        public int? ManagerId { get; set; }
        public bool IsManager { get; set; } = false;
    }
}
