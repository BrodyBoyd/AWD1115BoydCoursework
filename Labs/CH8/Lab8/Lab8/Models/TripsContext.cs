using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Lab8.Models
{
    public class TripsContext(DbContextOptions<TripsContext> options) : DbContext(options)
    {
        public DbSet<Trip> Trips { get; set; }
    }
}
