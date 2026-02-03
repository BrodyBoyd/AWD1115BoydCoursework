using System;
using Microsoft.EntityFrameworkCore;

namespace HOT2.Models
{
    public class ProductContext(DbContextOptions<ProductContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Name = "Baseball", Description = "Great for throwing around or even hitting", ImageUrl = "baseball.png", Price = 3, Quantity = 0 },
                new Product { ProductId = 2, Name = "Roller Skates", Description = "Great for getting around your town or even skating on a rink", ImageUrl = "rollerSkate.png", Price = 14, Quantity = 0 },
                new Product { ProductId = 3, Name = "Toyota Camary", Description = "Reliable Car that will last a lifetime", ImageUrl = "toyota.png", Price = 24199.99m, Quantity = 0 },
                new Product { ProductId = 4, Name = "Computer", Description = "Able to do work and play games on", ImageUrl = "Computer.png", Price = 800, Quantity = 0 },
                new Product { ProductId = 5, Name = "Chair", Description = "Pairs great with a office space and will make your back and butt not hurt after a long work day", ImageUrl = "chair.png", Price = 50, Quantity = 0 }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Sports" },
                new Category { CategoryId = 2, CategoryName = "Vehicle" },
                new Category { CategoryId = 3, CategoryName = "Office" },
                new Category { CategoryId = 4, CategoryName = "Other" }
            );
        }
    }
}
