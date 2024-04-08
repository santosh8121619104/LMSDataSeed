using LMSDataSeed.DataSeed;
using LMSDataSeed.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace LMSDataSeed
{
    public class DataSeeder
    {
        public static async Task Run(LmsContext lmsContext)
        {
            var dataseeder = new List<IEntitySeeder>();
            dataseeder.Add(new CategoriesSeeder());
            dataseeder.Add(new UsersSeeder());
            dataseeder.Add(new CoursesSeeder());

            foreach(var seeder  in dataseeder)
            {
                seeder.run(lmsContext);
                await lmsContext.SaveChangesAsync();
            }
        }

    }
}
