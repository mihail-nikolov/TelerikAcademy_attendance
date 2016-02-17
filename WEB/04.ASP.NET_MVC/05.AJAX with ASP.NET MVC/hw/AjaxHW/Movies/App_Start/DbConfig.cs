using Movies.Data;
using System.Data.Entity;
using Movies.Migrations;

namespace Movies
{
    public class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MoviesDbContext, Configuration>());
            MoviesDbContext.Create().Database.Initialize(true);
        }
    }
}