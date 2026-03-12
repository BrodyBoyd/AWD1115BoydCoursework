using Microsoft.EntityFrameworkCore;

namespace Lab11.Models
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Sales> Sales { get; set; }


    }
}
