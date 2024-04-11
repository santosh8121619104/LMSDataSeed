using LMSDataSeed.Models;
using Microsoft.EntityFrameworkCore;

namespace LMSDataSeed.DataSeed
{
    public class LessonStepSeeder : IEntitySeeder
    {
        public bool run(LmsContext context)
        {
            if (!context.LessonSteps.Any())
            {
                var lessonSteps = new List<LessonStep>();

                // Iterate over each course
                foreach (var course in context.Courses.Include(a=>a.Lessons))
                {
                    // Iterate over each lesson in the course
                    foreach (var lesson in course.Lessons)
                    {
                        var random = new Random();

                        // Generate a random number of steps for each lesson
                        int numberOfSteps = random.Next(3, 6); // Adjust the range as needed

                        for (int i = 1; i <= numberOfSteps; i++)
                        {
                            var step = new LessonStep
                            {
                                Lesson = lesson,
                               Course = course,
                                StepName = $"Step {i}",
                                Content = $"Content for Step {i}",
                                Runtime = GetRandomRuntime(),
                                CreatedBy = "Seeder", 
                                CreateDate = DateTimeOffset.UtcNow,
                                IsPaid = true,
                                ContentType = 1 
                            };

                            lessonSteps.Add(step);
                        }
                    }
                }

                // Add lesson steps to the context
                context.LessonSteps.AddRange(lessonSteps);
                context.SaveChanges();

                return true;
            }

            return false;
        }

        // Method to generate a random runtime
        private TimeOnly GetRandomRuntime()
        {
            var random = new Random();
            int hours = random.Next(0, 3); // Random hours between 0 and 2
            int minutes = random.Next(0, 60); // Random minutes between 0 and 59
            int seconds = random.Next(0, 60); // Random seconds between 0 and 59

            return new TimeOnly(hours, minutes, seconds);
        }
    }
}
