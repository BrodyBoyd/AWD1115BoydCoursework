using Microsoft.EntityFrameworkCore;

namespace Ch6Lab.Models
{
    public class FaqsContext : DbContext
    {
        public FaqsContext(DbContextOptions<FaqsContext> options) : base(options)
        {
        }

        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Topic> Topics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = "gen", Name = "General" },
                new Category { CategoryId = "hist", Name = "History" }
            );

            modelBuilder.Entity<Topic>().HasData(
                new Topic { TopicId = "asp", Name = "ASP .NET Core" },
                new Topic { TopicId = "blz", Name = "Blazor" },
                new Topic { TopicId = "ef", Name = "Entity Framework" }
            );

            modelBuilder.Entity<FAQ>().HasData(
                new FAQ { FAQId = 1, Question = "What is ASP.NET Core?", Answer = "ASP.NET Core is a free open-source web framework.", CategoryId = "gen", TopicId = "asp" },
                new FAQ { FAQId = 2, Question = "When was ASP.NET Core released?", Answer = "ASP.NET Core 1.0 was released on June 27, 2016.", CategoryId = "hist", TopicId = "asp" },
                new FAQ { FAQId = 3, Question = "What is Blazor?", Answer = "Blazor is a free and open-source web framework.", CategoryId = "gen", TopicId = "blz" },
                new FAQ { FAQId = 4, Question = "When was Blazor released?", Answer = "Blazor was released on May 14, 2020.", CategoryId = "hist", TopicId = "blz" },
                new FAQ { FAQId = 5, Question = "What is Entity Framework?", Answer = "Entity Framework is an open-source ORM for .NET applications supported by Microsoft.", CategoryId = "gen", TopicId = "ef" },
                new FAQ { FAQId = 6, Question = "When was Entity Framework released?", Answer = "Entity Framework 1.0 was released in 2008.", CategoryId = "hist", TopicId = "ef" }
            );
        }
    }
}
