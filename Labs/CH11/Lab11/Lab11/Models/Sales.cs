using System.ComponentModel.DataAnnotations.Schema;

namespace Lab11.Models
{
    public class Sales
    {
        public int SalesId { get; set; }
        public int Quarter { get; set; }
        public int Year { get; set; }
        // The database migration created a column named "AccountNumber".
        // Map the model's Amount property to that column so EF won't look for a column named "Amount".
        [Column("AccountNumber")]
        public double Amount { get; set; }

        // The database has an EmployeeId column. Expose the FK and a navigation property.
        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee? EmployeeRef { get; set; }

        // Keep a convenience property for views that shows the employee's name.
        // Marked as NotMapped so EF won't expect an "Employee" column.
        [NotMapped]
        public string Employee => EmployeeRef is null ? string.Empty : $"{EmployeeRef.FirstName} {EmployeeRef.LastName}";

        
    }
}
