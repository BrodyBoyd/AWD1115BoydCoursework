using Microsoft.EntityFrameworkCore;
using TripManyToMany.Models;
namespace TripManyToMany.Data
{
    public class TripsContext(DbContextOptions<TripsContext> options) : DbContext(options)
    {
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Accommodation> Accommodations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Configure the relationship and DeleteBehavior
            modelBuilder.Entity<Trip>()
                .HasOne(t => t.Destination)      // Trip has one Destination
                .WithMany(d => d.Trips)          // Destination has many Trips
                .HasForeignKey(t => t.DestinationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Trip>()
                .HasOne(t => t.Accommodation)      // Trip has one Destination
                .WithMany(a => a.Trips)          // Destination has many Trips
                .HasForeignKey(t => t.AccommodationId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Destination>().HasData(
                new Destination { DestinationId = 1, DestinationName = "New York City" }
                );

            

            modelBuilder.Entity<Accommodation>().HasData(
                new Accommodation { AccommodationId = 1, Name = "The Rits Hotel" }
                );

            modelBuilder.Entity<Activity>().HasData(
                new Activity { ActivityId = 1, Name = "The Zoo" }
                );

            modelBuilder.Entity<Trip>().HasData(
                new Trip { TripId = 1, StartDate = new DateTime(2024, 1, 1), EndDate = new DateTime(2024, 5, 2), DestinationId = 1, AccommodationId = 1},
                new Trip { TripId = 2, StartDate = new DateTime(2025, 1, 1), EndDate = new DateTime(2025, 5, 2), DestinationId = 1, AccommodationId = 1 }

                );

            modelBuilder.Entity<Trip>()
                .HasMany(t => t.Activities)
                .WithMany(a => a.Trips)
                .UsingEntity(j => j.HasData(
                    new { TripsTripId = 1, ActivitiesActivityId = 1 },
                    new { TripsTripId = 2, ActivitiesActivityId = 1 }
                    ));
        }
    }
}
