namespace Teleimot.Web.Api.App_Start
{
    using System.Data.Entity;
    using Data;
    using Data.Migrations;

    public class DataBaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TeleimotDbContext, Configuration>());
            TeleimotDbContext.Create().Database.Initialize(true);
        }
    }
}