using Microsoft.EntityFrameworkCore;

namespace lab12.Models
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
               new Student { StudentId = 1, Name = "Brody Boyd", FinancialAidStatus = "Passed" },
               new Student { StudentId = 2, Name = "Frank Sposito Jr.", FinancialAidStatus = "Passed" },
               new Student { StudentId = 3, Name = "Munkbaht Carlson", FinancialAidStatus = "Not completed" },
               new Student { StudentId = 4, Name = "Isaiah Hostetter", FinancialAidStatus = "Pending" }
                );

            modelBuilder.Entity<Course>().HasData(
                new Course { CourseId = 1, Title = "Web Development"},
                new Course { CourseId = 2, Title = "Engineering"},
                new Course { CourseId = 3, Title = "Business" }
                );

            modelBuilder.Entity<Student>().HasMany(s => s.Courses).WithMany(c => c.Students).UsingEntity(sc => sc.HasData(
                new { CoursesCourseId = 1, StudentsStudentId = 1},
                new { CoursesCourseId = 2, StudentsStudentId = 3},
                new { CoursesCourseId = 3, StudentsStudentId = 2},
                new { CoursesCourseId = 2, StudentsStudentId = 4},
                new { CoursesCourseId = 1, StudentsStudentId = 3},
                new { CoursesCourseId = 2, StudentsStudentId = 1}
                ));
        }
    }
}
