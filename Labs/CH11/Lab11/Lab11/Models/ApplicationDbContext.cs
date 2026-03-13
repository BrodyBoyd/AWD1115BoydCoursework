using Microsoft.EntityFrameworkCore;

namespace Lab11.Models
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Sales> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Birthday = new DateTime(1980, 1, 1),
                    HireDate = new DateTime(2010, 1, 1),
                    IsManager = true,
                    ManagerId = 0,
                }
            );
        }


    }
}
