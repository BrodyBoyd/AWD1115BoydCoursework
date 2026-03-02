using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ShoppingCartLab.Models
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Vehicle", Description = "Vehicles for getting around." },
                new Category { CategoryId = 2, Name = "Shirt", Description = "Shirts for wearing." },
                new Category { CategoryId = 3, Name = "Gadget", Description = "Gadgets for doing things." }
            );

            builder.Entity<Product>().HasData(
                new Product { ProductId = 1, Name = "Skateboard", Description = "A skateboard for getting around.", StockQuantity = 15, Price = 34.99m, CategoryId = 1, ImageUrl = "~/images/skateboard.png" },
                new Product { ProductId = 2, Name = "White T-Shirt", Description = "A t-shirt for wearing.", StockQuantity = 24, Price = 14.99m, CategoryId = 2, ImageUrl = "~/images/whiteShirt.jpg" },
                new Product { ProductId = 3, Name = "Peach T-Shirt", Description = "A t-shirt for wearing.", StockQuantity = 3, Price = 14.99m, CategoryId = 2, ImageUrl = "~/images/pinkShirt.png" },
                new Product { ProductId = 4, Name = "Smartphone", Description = "A smartphone for doing things.", StockQuantity = 19, Price = 499.99m, CategoryId = 3, ImageUrl = "https://m.media-amazon.com/images/I/510lvJQeb-L.jpg" }
            );
        }

    }
}
