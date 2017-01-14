namespace School.Data.Migrations
{
    using School.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<School.Data.NameDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            ContextKey = "School.Data.NameDbContext";
        }

        protected override void Seed(School.Data.NameDbContext context)
        {
            //      This method will be called after migrating to the latest version.

            //      You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //      to avoid creating duplicate seed data. E.g.

            context.Students.AddOrUpdate(
           s => s.Name,
           new Student { Name = "Andrew Peters" },
           new Student { Name = "Brice Lambson" },
           new Student { Name = "Rowan Miller" }
         );

        }
    }
}
