using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models
{
    public class ToDoItemContext(DbContextOptions<ToDoItemContext> options) : DbContext(options)
    {
        public DbSet<ToDoItem> ToDoItems { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Status> Statuses { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().HasData(
                new Category { CategoryId = "work", Name = "Work" },
                new Category { CategoryId = "home", Name = "Home" },
                new Category { CategoryId = "ex", Name = "Exercise" },
                new Category { CategoryId = "shop", Name = "Shopping" },
                new Category { CategoryId = "call", Name = "Contact" }
            );

            builder.Entity<Status>().HasData(
               new Status { StatusId = "open", Name = "Open" },
               new Status { StatusId = "closed", Name = "Completed" }
           );
        }
    }
}
