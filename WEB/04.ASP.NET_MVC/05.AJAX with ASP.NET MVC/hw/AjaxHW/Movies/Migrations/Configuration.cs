namespace Movies.Migrations
{
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Movies.Data.MoviesDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Data.MoviesDbContext context)
        {
            if (context.Studios.Any())
            {
                return;
            }
            var studios = new List<Studio>
            {
                new Studio() { Name = "studio1", Address = "address1" },
                new Studio() { Name = "studio2", Address = "address2" },
                new Studio() { Name = "studio3", Address = "address3" },
                new Studio() { Name = "studio4", Address = "address4" }
            };

            var actresses = new List<Actress>
            {
                 new Actress() { Name = "Actress1", Age = 25 },
                new Actress() { Name = "Actress2", Age = 26 },
                new Actress() { Name = "Actress3", Age = 27 },
                new Actress() { Name = "Actress4", Age = 28 }
            };

            var actors = new List<Actor>
            {
                new Actor() { Name = "Actor1", Age = 35 },
                new Actor() { Name = "Actor2", Age = 36 },
                new Actor() { Name = "Actor3", Age = 37 },
                new Actor() { Name = "Actor4", Age = 38 }
            };

            var directors = new List<Director>
            {
                new Director() { Name = "Director1", Age = 55 },
                new Director() { Name = "Director2", Age = 56 },
                new Director() { Name = "Director3", Age = 57 },
                new Director() { Name = "Director4", Age = 58 }
            };

            context.Studios.AddOrUpdate(
                s => s.Name,
                studios[0],
                studios[1],
                studios[2],
                studios[3]
            );

            context.Directors.AddOrUpdate(
                d => d.Name,
                directors[0],
                directors[1],
                directors[2],
                directors[3]
            );

            context.Actors.AddOrUpdate(
                a => a.Name,
                actors[0],
                actors[1],
                actors[2],
                actors[3]
            );

            context.Actresses.AddOrUpdate(
                a => a.Name,
                actresses[0],
                actresses[1],
                actresses[2],
                actresses[3]
            );

            context.Movies.AddOrUpdate(
                m => m.Title,
                new Movie() { Title = "Movie1", Director = directors[0], Studio = studios[0], LeadingFemaleRole = actresses[0], LeadingMaleRole = actors[0], Year = 2001 },
                new Movie() { Title = "Movie2", Director = directors[1], Studio = studios[1], LeadingFemaleRole = actresses[1], LeadingMaleRole = actors[1], Year = 2002 },
                new Movie() { Title = "Movie3", Director = directors[2], Studio = studios[2], LeadingFemaleRole = actresses[2], LeadingMaleRole = actors[2], Year = 2003 },
                new Movie() { Title = "Movie4", Director = directors[3], Studio = studios[3], LeadingFemaleRole = actresses[3], LeadingMaleRole = actors[3], Year = 2004 }
            );
        }
    }
}
