using LMSDataSeed.Models;

namespace LMSDataSeed.DataSeed
{
    public class CategoriesSeeder:IEntitySeeder
    {
        public bool run(LmsContext context)
        {
            if (!context.Categories.Any()) {
                var categories = new List<Category>
                {
                    new() { CategoryName = "Web Development"},
                     new() { CategoryName = "Design"},
                      new() { CategoryName = "IOS & Swift"},
                       new() { CategoryName = "Android"},
                        new() { CategoryName = "Business"},
                         new() { CategoryName = "PhotoGraphy"},
                          new() { CategoryName = "Marketing"},
                           new() { CategoryName = "eCommerce"},
                            new() { CategoryName = "Health and Fitness"},
                             new() { CategoryName = "Music"}
                };
                context.Categories.AddRange(categories);
                return true;

            } return false;
        }
    }
}
