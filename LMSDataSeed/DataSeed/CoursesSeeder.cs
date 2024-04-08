using LMSDataSeed.Models;

namespace LMSDataSeed.DataSeed
{
    public class CoursesSeeder : IEntitySeeder
    {
        public bool run(LmsContext context)
        {
            try
            {
                if (!context.Courses.Any())
                {
                    var courseNames = new List<string> { "Web Development", "Design", "IOS & Swift", "Android", "Business", "Photography", "Marketing", "eCommerce", "Health and Fitness", "Music" };
                    var descriptions = new List<string> { "Learn web development with HTML, CSS, and JavaScript.", "Explore principles of design and enhance your creativity.", "Master iOS app development using Swift.", "Build Android apps using Java and Kotlin.", "Discover strategies for running a successful business.", "Improve your photography skills.", "Learn about marketing strategies and techniques.", "Understand eCommerce platforms and tactics.", "Stay fit and healthy with our fitness courses.", "Learn to play musical instruments and compose music." };
                    var random = new Random();

                    var categories = context.Categories.ToList(); // Retrieve all categories from the database
                    var users = context.Users.ToList(); 
                    var courses = new List<Course>();
                    foreach (var categoryName in courseNames)
                    {
                        var categoryId = categories.FirstOrDefault(c => c.CategoryName.ToLower() == categoryName.ToLower())?.CategoryId ?? 0;
                        var description = descriptions[random.Next(descriptions.Count)];
                        courses.Add(new Course
                        {
                            CourseName = categoryName,
                            Description = description,
                            CategoryId = categoryId,
                            Instructor = users[random.Next(users.Count)],
                        });
                    }

                    context.Courses.AddRange(courses);
                    return true;
                }
            }
            catch (Exception ex)
            {
                // Handle the error, either log it or throw an exception
                throw new Exception("An error occurred while seeding courses.", ex);
            }

            return false;
        }

        private string GetRandomElement(List<string> list)
        {
            var random = new Random();
            return list[random.Next(list.Count)];
        }
    }
}
