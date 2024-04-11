using LMSDataSeed.Models;

namespace LMSDataSeed.DataSeed
{
    public class LessonsSeeder : IEntitySeeder
    {
        public bool run(LmsContext context)
        {
            if (!context.Lessons.Any())
            {
                var courses = context.Courses.ToList();
                if (courses.Count == 0)
                {
                    // No courses available, cannot create lessons
                    return false;
                }

                var lessons = new List<Lesson>();
                var random = new Random();

                foreach (var course in courses)
                {
                    var numberOfLessons = random.Next(5, 10); // Random number of lessons per course
                    for (int i = 0; i < numberOfLessons; i++)
                    {
                        var lesson = new Lesson
                        {
                            CourseId = course.CourseId,
                            LessonName = $"Lesson {i + 1} for {course.CourseName}",
                            Content = $"Content for Lesson {i + 1} of {course.CourseName}",
                            CreatedBy = "Admin",
                            CreateDate = DateTimeOffset.UtcNow,
                            ModifiedBy = "Admin",
                            ModifiedDate = DateTimeOffset.UtcNow,
                            IsPaid = false,
                            ContentType = 1 // Replace with the appropriate content type ID
                        };
                        lessons.Add(lesson);
                    }
                }

                context.Lessons.AddRange(lessons);
                context.SaveChanges();
                return true;
            }

            return false;
        }
    }

}
