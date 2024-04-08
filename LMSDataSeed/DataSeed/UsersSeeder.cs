using LMSDataSeed.Models;

namespace LMSDataSeed.DataSeed
{
    public class UsersSeeder : IEntitySeeder
    {
        public bool run(LmsContext context)
        {
            try
            {
                if (!context.Users.Any())
                {
                    var firstNames = new List<string> { "John", "Alice", "Bob", "Emma", "Michael", "Sophia", "William", "Olivia", "James", "Emily", "Alexander", "Ava", "Jacob", "Isabella", "Matthew", "Charlotte", "Daniel", "Amelia", "Ethan", "Mia" };
                    var lastNames = new List<string> { "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor", "Anderson", "Thomas", "Jackson", "White", "Harris", "Martin", "Thompson", "Garcia", "Martinez", "Robinson" };

                    var users = new List<User>();

                    // Creating 20 users
                    for (int i = 0; i < 20; i++)
                    {
                        var user = new User
                        {
                            FirstName = GetRandomElement(firstNames),
                            LastName = GetRandomElement(lastNames),
                            Email = $"user{i + 1}@example.com",
                            Password = "password", 
                            UserType = "Student", 
                            CreatedBy = "Admin",
                            CreateDate = DateTimeOffset.UtcNow
                        };

                        users.Add(user);
                    }

                     context.Users.AddRange(users);
                     context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                // Handle the error, either log it or throw an exception
                throw new Exception("An error occurred while seeding users.", ex);
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
