using Microsoft.EntityFrameworkCore;

namespace EntityFramework03.Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new LearningPlatformDbContext();

            var instructor = new Instructor
            {
                FullName = "Ahmed Badawy",
                Email = "ahmed.Badawy@edu.com",
                Bio = ".NET Developer",
                JoinedDate = DateTime.Now
            };

            context.Instructors.Add(instructor);
            context.SaveChanges();
            Console.WriteLine("Instructor Added Successfully!");

            var course = context.Courses.FirstOrDefault();
            if (course != null)
            {
                Console.WriteLine($"Found Course: {course.Title} - Price: {course.Price}");
            }

            if (course != null)
            {
                course.Price = 200.00m;
                context.SaveChanges();
                Console.WriteLine("Course Price Updated.");
            }

            int updatedRows = context.Courses
                .Where(c => c.IsPublished)
                .ExecuteUpdate(s => s.SetProperty(c => c.Price, c => c.Price * 1.10m));

            Console.WriteLine($"{updatedRows} Courses Updated By Bulk Update.");
        }
    }
}