namespace TwitterLikeSystem.Migrations
{
    using System.Data.Entity.Migrations;
    using Data;
    using System.Linq;
    using Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    public sealed class Configuration : DbMigrationsConfiguration<TwitterLikeSystem.Data.TwitterDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TwitterDbContext context)
        {
            SeedRoles(context);
            SeedUsersAndAdmin(context);
        }

        private void SeedRoles(TwitterDbContext context)
        {
            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                var adminRole = new IdentityRole { Name = "Admin" };
                roleManager.Create(adminRole);

                context.SaveChanges();
            }
        }

        public void SeedUsersAndAdmin(TwitterDbContext context)
        {
            if (!context.Tweets.Any())
            {
                var userManager = new UserManager<User>(new UserStore<User>(context));

                var admin = new User()
                {
                    Email = "admin@abv.bg",
                    UserName = "admin"
                };
                userManager.Create(admin, "admin123");
                userManager.AddToRole(admin.Id, "Admin");
                context.SaveChanges();

                for (int i = 1; i <= 6; i++)
                {
                    var user = new User()
                    {
                        Email = string.Format ("user{0}@abv.bg", i.ToString()),
                        UserName = "user" + i.ToString()
                    };

                    userManager.Create(user, "user" + i.ToString());
                    context.Users.Add(user);
                    context.SaveChanges();

                    var newTweet = new Tweet()
                    {
                        Content = "Tweet" + i.ToString(),
                        UserId = user.Id,
                        tags = new List<Tag>() { new Tag() { Name = "Tag" + i.ToString() } }
                    };

                    var newTweet1 = new Tweet()
                    {
                        Content = "Tweet" + i.ToString() + "_" + i.ToString(),
                        UserId = user.Id,
                        tags = new List<Tag>() { new Tag() { Name = "Tag" + i.ToString() + "_" + i.ToString() } }
                    };

                    context.Tweets.Add(newTweet);
                    context.Tweets.Add(newTweet1);
                    context.SaveChanges();
                }

                context.SaveChanges();

            }
        }
    }
}
