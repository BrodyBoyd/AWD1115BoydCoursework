using Microsoft.EntityFrameworkCore;

namespace HOT4.Models
{
    public class AppointmentContext(DbContextOptions<AppointmentContext> options) : DbContext(options)
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerId = 1,
                    Username = "JohnDoe",
                    PhoneNumber = "1234567890"
                });
        }

    }
}
