using LMSDataSeed.Models;

namespace LMSDataSeed.DataSeed
{
    public interface IEntitySeeder
    {
        public bool run(LmsContext lmsContext);
    }
}
