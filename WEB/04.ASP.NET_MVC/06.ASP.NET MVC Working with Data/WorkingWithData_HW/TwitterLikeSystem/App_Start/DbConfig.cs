using System.Data.Entity;
using TwitterLikeSystem.Data;
using TwitterLikeSystem.Migrations;

namespace TwitterLikeSystem.App_Start
{
    public class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TwitterDbContext, Configuration>());
            TwitterDbContext.Create().Database.Initialize(true);
        }
    }
}