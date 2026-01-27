using System;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Use a fixed seed date so EF Core's model snapshot remains stable.
            var seedDate = new DateTime(2026, 1, 23, 13, 50, 54, 33, DateTimeKind.Local).AddTicks(9517);

            //Broken Code Below
            var seedDateBroken = DateTime.Now;

            modelBuilder.Entity<Contact>().HasData(
                new Contact { ContactId = 1, FirstName = "Terry", LastName = "Silver", CategoryId = 1, Email = "TSilver@gmail.com", PhoneNumber = "131-123-2351", DateAdded = seedDate },
                new Contact { ContactId = 2, FirstName = "Johnny", LastName = "Lawrence", CategoryId = 2, Email = "CobraKaiNeverDies@gmail.com", PhoneNumber = "417-163-7853", DateAdded = seedDate },
                new Contact { ContactId = 3, FirstName = "Ralph", LastName = "Miyagi", CategoryId = 3, Email = "MrMiyagiGoat@gmail.com", PhoneNumber = "616-137-2371", DateAdded = seedDate }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Family" },
                new Category { CategoryId = 2, CategoryName = "Friend" },
                new Category { CategoryId = 3, CategoryName = "Work" },
                new Category { CategoryId = 4, CategoryName = "Other" }
            );
        }
    }
}
