using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PeePal.Models
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Review> Reviews { get; set; }

        public DbSet<Bathroom> Bathrooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ensure Identity's model is configured first (defines keys for Identity entities)
            base.OnModelCreating(modelBuilder);

            // Configure many-to-many join table explicitly so EF Core will create it in migrations
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Favorites)
                .WithMany(b => b.FavoritedBy)
                .UsingEntity<Dictionary<string, object>>(
                    "UserFavoriteBathrooms",
                    j => j.HasOne<Bathroom>().WithMany().HasForeignKey("BathroomId").OnDelete(DeleteBehavior.Restrict),
                    j => j.HasOne<ApplicationUser>().WithMany().HasForeignKey("ApplicationUserId").OnDelete(DeleteBehavior.Restrict),
                    j =>
                    {
                        j.HasKey("ApplicationUserId", "BathroomId");
                        j.ToTable("UserFavoriteBathrooms");
                    });
        }
    }
}
