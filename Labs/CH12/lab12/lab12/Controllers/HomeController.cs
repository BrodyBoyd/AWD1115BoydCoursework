using lab12.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab12.Controllers
{
    public class HomeController(ApplicationDbContext _context) : Controller
    {
        private readonly ApplicationDbContext context = _context;
        public async Task<IActionResult> Index()
        {
            ViewBag.Courses = await context.Courses.ToListAsync();

            return View(await context.Students.ToListAsync());
        }
        public async Task<IActionResult> ChangeCourse(int courseId)
        {
            List<Student> studentsInCourse;
            ViewBag.Courses = await context.Courses.ToListAsync();
            ViewBag.SelectedCourse = courseId;

            if(courseId != 0)
            {
                studentsInCourse = await context.Students.Where(s => s.Courses.Any(c => c.CourseId == courseId)).ToListAsync();
            }
            else
            {
                studentsInCourse = await context.Students.ToListAsync();
            }
            return View("Index", studentsInCourse);

        }
        [HttpGet]
        public async Task<IActionResult> EnrollNewStudent()
        {
            ViewBag.Courses = await context.Courses.ToListAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EnrollNewStudent(Student s, string[] enrolledCourses)
        {
            if (enrolledCourses != null)
            {
                foreach(var courseId in enrolledCourses)
                {
                    Course c = context.Courses.Find(int.Parse(courseId));
                    s.Courses.Add(c);
                }
            }
            context.Students.Add(s);
            await context.SaveChangesAsync();
            List<Student> students = await context.Students.ToListAsync();
            ViewBag.Courses = await context.Courses.ToListAsync();

            return View("Index", students);
        }
        public async Task<IActionResult> ChangeEnrollment(int id)
        {
            var student = await context.Students.Include(s => s.Courses).FirstOrDefaultAsync(s => s.StudentId == id);
            ViewBag.Courses = await context.Courses.ToListAsync();
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> ModifyStudentEnrolledCourses(Student s, string[] enrolledCourses)
        {
            Student student = await context.Students.Where(st => st.StudentId == s.StudentId).Include(s => s.Courses).FirstOrDefaultAsync();
            student.Courses.Clear();
            if (enrolledCourses != null)
            {
                foreach(var courseId in enrolledCourses)
                {
                    Course c = context.Courses.Find(int.Parse(courseId));
                    student.Courses.Add(c);
                }
            }
            await context.SaveChangesAsync();
            List<Student> students = await context.Students.ToListAsync();
            ViewBag.Courses = await context.Courses.ToListAsync();
            return View("Index", students);
        }

        public async Task<IActionResult> DeleteStudent(int id)
        {
            return View(await context.Students.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteStudent(Student s)
        {
            context.Students.Remove(s);
            await context.SaveChangesAsync();
            List<Student> students = await context.Students.ToListAsync();
            ViewBag.Courses = await context.Courses.ToListAsync();
            return View("Index", students);
        }
    }
}
