namespace FitnessSystem.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using FitnessSystem.Common;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        private Dictionary<string, Category> CategoriesCollection;
        private Dictionary<string, ApplicationUser> UsersCollection;
        Random rnd = new Random();

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            this.SeedUsersAndAdmin(context);
            this.SeedFeedback(context);
            try
            {
                this.SeedExercisesCategoriesVotes(context);
            }
            catch (Exception ex)
            {

            }
        }

        private void SeedUsersAndAdmin(ApplicationDbContext context)
        {
            const string AdministratorUserName = "admin@admin.com";
            const string AdministratorPassword = AdministratorUserName;
            this.UsersCollection = new Dictionary<string, ApplicationUser>();

            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = GlobalConstants.AdministratorRoleName };
                roleManager.Create(role);

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var admin = new ApplicationUser { UserName = AdministratorUserName, Email = AdministratorUserName };
                userManager.Create(admin, AdministratorPassword);
                userManager.AddToRole(admin.Id, GlobalConstants.AdministratorRoleName);

                for (int i = 1; i <= 15; i++)
                {
                    string userName = string.Format("user{0}@site.com", i.ToString());
                    string password = userName;
                    var user = new ApplicationUser { UserName = userName, Email = userName };
                    userManager.Create(user, password);
                    this.UsersCollection.Add(user.UserName, user);
                }
            }
        }

        private void SeedFeedback(ApplicationDbContext context)
        {
            if (!context.FeedBacks.Any())
            {
                Feedback hateFeedBack1 = new Feedback()
                {
                    Title = "pedali ste",
                    Content = "you suck!!!"
                };
                context.FeedBacks.Add(hateFeedBack1);

                Feedback hateFeedBack2 = new Feedback()
                {
                    Title = "fuck you",
                    Content = "super smotan SAIT"
                };
                context.FeedBacks.Add(hateFeedBack2);

                Feedback goodFeedback = new Feedback()
                {
                    Title = "I love it",
                    Content = "it is a very good idea to have fitness system with exercises!"
                };
                context.FeedBacks.Add(goodFeedback);

                for (int i = 1; i <= 15; i++)
                {
                    string title = string.Format("feedback", i.ToString());
                    string content = string.Format("feedback Content {0}", i.ToString());

                    Feedback feedback = new Feedback()
                    {
                        Title = title,
                        Content = content
                    };

                    context.FeedBacks.Add(feedback);
                }
                context.SaveChanges();

            }
        }

        private void SeedCategories(ApplicationDbContext context)
        {
            if (!context.Categories.Any())
            {

            }
        }

        private void AddVotes(Exercise exercise)
        {
            for (int i = 1; i <= 50; i++)
            {
                Vote vote = new Vote()
                {
                    Points = this.rnd.Next(-1, 2)
                };
                exercise.Votes.Add(vote);
            }
        }

        private void SeedExercisesCategoriesVotes(ApplicationDbContext context)
        {
            if (!context.Categories.Any())
            {
                // ===========================================================================
                var categoryLegs = new Category()
                {
                    Name = "Legs",
                    IsVisible = true
                };

                Exercise exercise8 = new Exercise
                {
                    Title = "7 Exercises to Work Your Legs to Exhaustion ",
                    Author = this.UsersCollection["user5@site.com"],
                    AuthorId = this.UsersCollection["user5@site.com"].Id,
                    Content = @"Well, for one, they can hide weak development with 90's retro bodybuilding pants but the main reason is they don’t want to do the hard work. Tom Platz and Branch Warren have the two best sets of wheels to ever grace the bodybuilding stage and what do they have in common? Only being the two hardest-working bodybuilders of all-time.

                For a leg-training workout to be productive it has to be an intense and brutal session—except for a few genetic anomalies, there is no way around it. Your legs are made up of the largest muscles in your body so you gotta train heavy! Ronnie Coleman did reps with 800 pounds in the squat.

                Big legs require big weights, right? However, there is more. Besides the amazing strength of the legs, they have tons of endurance. Everywhere you walk, bike, or play, you use your legs. For this reason, legs need a lot of volume.

                Let’s take a look at seven exercises to work your legs to exhaustion."
                };
                this.AddVotes(exercise8);
                categoryLegs.Exercises.Add(exercise8);

                Exercise exercise9 = new Exercise
                {
                    Title = "2 Best Methods to Build a Sexy V-Taper",
                    Author = this.UsersCollection["user5@site.com"],
                    AuthorId = this.UsersCollection["user5@site.com"].Id,
                    Content = @"KEY MOVES

                    For shoulders: Leaning one-arm side lateral raise, behind-the-back one-arm cable lateral.
                    For back: Straight-arm rope pulldown, wide-grip chinup.
                    For quads: Single-leg press, narrow-stance hack squat (add a pulse or half rep at the bottom).
                    For waist: Ab vacuum.

                TRAINING NOTES

                “The key to creating that V-taper look is to work on rounding out your shoulders, widening your lats, keeping a lean, tight waistline, and getting a bigger quad sweep. If you can keep your abs at least somewhat visible you are able to achieve that look year-round. But for that tight waist, your diet needs to be 90% perfect in the off-season. Focus on keeping your diet clean and eating carbs around your workout so your muscles can best utilize them.” "
                };
                this.AddVotes(exercise9);
                categoryLegs.Exercises.Add(exercise9);

                Exercise exercise10 = new Exercise
                {
                    Title = "Jump Rope Workout to Burn More Fat in Less Time ",
                    Author = this.UsersCollection["user5@site.com"],
                    AuthorId = this.UsersCollection["user5@site.com"].Id,
                    Content = @"When you think of a typical fat-burning workout, what’s the first thing that comes to mind?

                If you’re thinking of long cardio routines or boring treadmill sessions, think again. There’s a much more effective way to get that chiseled-physique.

                SEE ALSO: CrossFit Physique: Extreme Jump Rope>>

                In fact, it has been proven that shorter workouts with varying levels of intensity can burn more fat than long steady state cardio routines. One study done by researchers at Laval University in Quebec, Canada found HIIT to be nine times more effective for losing fat than steady-state cardio. "
                };
                this.AddVotes(exercise10);
                categoryLegs.Exercises.Add(exercise10);

                context.Categories.Add(categoryLegs);
                context.SaveChanges();

                // ===========================================================================
                var categoryBack = new Category()
                {
                    Name = "Back",
                    IsVisible = true
                };

                Exercise exercise4 = new Exercise
                {
                    Title = "Train Zane's Way: Spread Your Lats ",
                    Author = this.UsersCollection["user3@site.com"],
                    AuthorId = this.UsersCollection["user3@site.com"].Id,
                    Content = @"I did lots of bentover barbell rows while training for the Olympia in 1976. I’d start each workout with this exercise, working up heavy. This gave me much improved lats but also a tennis-elbow-like injury from excessive pronation of the overhand grip. So what to do? Switch to a neutral grip and employ the leverage row, aka the T-bar row. 

                It’s best to to stick a seven-foot Olympic bar in the corner and load one end with small diameter plates so you have a big range of motion. (If you’re really getting the bar up, 45s can hit your chest.) I use 10s and wouldn’t use more than 25s. 

                SEE ALSO: Frank Zane's 4 Secrets to a Smaller Waist>>

                Straddle the bar and interlace your fingers. Bend your knees so your upper body is parallel to the floor. I pull the weight up until it touches my chest and then lower it slowly, being sure to round my back slightly (but safely) as I let the weight down. It’s important to round your back to maximize the stretch. If you keep your lower back arched you’ll contract upper-back muscles, but you won’t target your low central lats. You have to stretch the lats to ensure full development.

                Quick Tip: Stretch the lats with front-lat spreads of 30 seconds between sets and hold the down position of one-arm rows for 15 seconds."
                };
                categoryBack.Exercises.Add(exercise4);
                this.AddVotes(exercise4);

                Exercise exercise5 = new Exercise
                {
                    Title = "The Ultimate Back Building Workout for 2016 ",
                    Author = this.UsersCollection["user3@site.com"],
                    AuthorId = this.UsersCollection["user3@site.com"].Id,
                    Content = @"If you are looking to build a physique that screams alpha male physical prowess and drips with masculine virility,
                                a well - developed back is the gateway to a truly dominant,
                                functional physique.

                Bill 'Kaz' Kazmaier,
                                the strongest man of all - time,
                                says, “A strong back equals a strong man.'  I won’t argue with Kaz and neither should you.


                The three best backs of all - time in bodybuilding are Ronnie Coleman, Lee Haney and Dorian Yates.These three men have a combined 22 Sandows.As soon as the IFBB judges saw their backs, it was game over and the battle ensued for second place for everyone else. If size and / or strength are important to you, back development is fundamental and the best method for that next level back development is powerbuilding. "
                };
                this.AddVotes(exercise5);
                categoryBack.Exercises.Add(exercise5);

                context.Categories.Add(categoryBack);
                context.SaveChanges();

                // ===========================================================================
                var categoryChest = new Category()
                {
                    Name = "Chest",
                    IsVisible = true
                };

                Exercise exercise6 = new Exercise
                {
                    Title = "8 Best Non-Bench Chest Exercises ",
                    Author = this.UsersCollection["user4@site.com"],
                    AuthorId = this.UsersCollection["user4@site.com"].Id,
                    Content = @"Just because it’s chest day doesn’t mean you're relegated to park your backside on a bench for your session. While the bench is a valuable tool for overall chest strength, it can place excess stress on the delts, which can be tough for those with injured shoulders. For pure pec muscle growth, there are several exercises that will get you off the bench and on your way to chest growth in PECtacular fashion.

                SEE ALSO: 4 Key Techniques to Maximize Chest Size>>

                Try mixing it up by performing these 8 exercises to hit the chest from all different angles. Once you begin incorporating these movements into your chest workout, you’ll be noticing a thicker, fuller, more developed chest in no time flat."
                };
                this.AddVotes(exercise6);
                categoryChest.Exercises.Add(exercise6);

                Exercise exercise7 = new Exercise
                {
                    Title = "Expert Q+A: How To Fight The Bra Bulge ",
                    Author = this.UsersCollection["user4@site.com"],
                    AuthorId = this.UsersCollection["user4@site.com"].Id,
                    Content = @"Q: 'I've been working out for years, but now that I'm over age 40,
                                I've noticed I'm getting some unsightly bulges around the front sides of my bra.What can I do? '


                A: “Body fat tends to become much more stubborn as we get older, especially after age 35,” says Michelle Johnson, an IFBB bikini pro and trainer based in Washington, D.C. “Continue to train your upper pecs with presses and pec flyes on an incline bench.Try 12, 10, 8, and 12 reps to start, increasing weight each set except for the last,” she says.For this larger muscle group, heavier weights develop muscle better. “Also add in the pec deck or dumbbell flye and the lat pulldown machine to tone the upper body.Cable flyes also challenge those muscles and target the fleshy underarm area.” Plus, try doing iso flyes and iso pulldowns with a resistance band between sets, which recruit stabilizer muscles in a big way. “And to help with loose skin, try green tea extract and collagen supplements, which may boost elasticity,” Johnson adds. "
                };
                this.AddVotes(exercise7);
                categoryChest.Exercises.Add(exercise7);

                context.Categories.Add(categoryChest);
                context.SaveChanges();

                // ===========================================================================
                var categoryArms = new Category()
                {
                    Name = "Arms",
                    IsVisible = true
                };
                context.Categories.Add(categoryArms);
                context.SaveChanges();

                // ===========================================================================
                var categoryShoulders = new Category()
                {
                    Name = "Shoulders",
                    IsVisible = true
                };

                Exercise exercise11 = new Exercise
                {
                    Title = "10 Tricks for Bigger, Healthier Shoulders  ",
                    Author = this.UsersCollection["user6@site.com"],
                    AuthorId = this.UsersCollection["user6@site.com"].Id,
                    Content = @"There is no denying it, great shoulders complete a physique. They give you width and top off that coveted V-taper. Your waist can be as small as can be, but without a killer pair of delts it will just not look right. Sadly, great or even good shoulders are rare these days and it is not due to lack of effort. If one takes a look around in most gyms, they’ll find that most shoulders are slopped forward and/or injured. Rarely do your see a nice pair of cannonball delts so I made it my mission to change that sorry state of affairs.

                In my opinion, the main reason that most trainees do not develop the shoulders they should have is because they are not fully balanced and therefore prone to injury as well as poor progress.

                Here are 10 tricks to make your shoulders big and healthy at the same time"
                };
                this.AddVotes(exercise11);
                categoryShoulders.Exercises.Add(exercise11);

                Exercise exercise2 = new Exercise
                {
                    Title = "10 Tricks for Bigger, Healthier Shoulders ",
                    Author = this.UsersCollection["user2@site.com"],
                    AuthorId = this.UsersCollection["user2@site.com"].Id,
                    Content = @"There is no denying it, great shoulders complete a physique. They give you width and top off that coveted V-taper. Your waist can be as small as can be, but without a killer pair of delts it will just not look right. Sadly, great or even good shoulders are rare these days and it is not due to lack of effort. If one takes a look around in most gyms, they’ll find that most shoulders are slopped forward and/or injured. Rarely do your see a nice pair of cannonball delts so I made it my mission to change that sorry state of affairs.

                In my opinion, the main reason that most trainees do not develop the shoulders they should have is because they are not fully balanced and therefore prone to injury as well as poor progress.

                Here are 10 tricks to make your shoulders big and healthy at the same time."
                };
                this.AddVotes(exercise2);
                categoryShoulders.Exercises.Add(exercise2);

                Exercise exercise3 = new Exercise
                {
                    Title = "Get More Out of Your Lateral Raises ",
                    Author = this.UsersCollection["user2@site.com"],
                    AuthorId = this.UsersCollection["user2@site.com"].Id,
                    Content = @"There are some things in your training regimen you do because, well, everybody does them. Everyone benches for a big chest, and if you want big legs, you squat. But sometimes the masses seem more like lemmings -- they aren't sure what or why they're doing something. They just do it because they believe they should, which brings us to the dumbbell lateral raise. Just about anyone who does this exercise raises the weights to only shoulder level, arms about parallel to the floor, but no higher. Know why? Think it causes rotator-cuff impingement and is dangerous to go above that point? Uh-uh. Think the arms-parallel position is where the middle delt stops working?

                Wrong again.
                While the concern over rotator-cuff impingement is real, Brockhoeft notes this fear can be minimized in two ways. First, slightly supinate your wrists (turn your palms up) on the way up if necessary. Second, instead of bringing the weights directly out to your sides, raise your arms in a wide V formation, about 10-15 degrees in front of your torso.

                Both modifications should improve the comfort of your lateral raises."
                };
                this.AddVotes(exercise3);
                categoryShoulders.Exercises.Add(exercise3);

                Exercise exercise12 = new Exercise
                {
                    Title = "7 Tips to Stay Fit at Work ",
                    Author = this.UsersCollection["user6@site.com"],
                    AuthorId = this.UsersCollection["user6@site.com"].Id,
                    Content = @"Despite knowing that sitting all day at work can take a toll on our health, a lot of us do nothing about it. Sure, it certainly is tough to find the time to exercise regularly, but even if you work out religiously, the bad news is that sitting for prolonged periods of time daily can kill you slowly.  

                SEE ALSO: The 9 Highest Paying Fitness Jobs

                Since you obviously can’t take a different career path to stay fit, you have to ensure that you don’t let your job stop you from staying active. If you don’t know how to begin, here are seven tips that are sure to help."
                };
                this.AddVotes(exercise12);
                categoryShoulders.Exercises.Add(exercise12);

                Exercise exercise13 = new Exercise
                {
                    Title = "7 Tips to Stay Fit at Work ",
                    Author = this.UsersCollection["user6@site.com"],
                    AuthorId = this.UsersCollection["user6@site.com"].Id,
                    Content = @"Despite knowing that sitting all day at work can take a toll on our health, a lot of us do nothing about it. Sure, it certainly is tough to find the time to exercise regularly, but even if you work out religiously, the bad news is that sitting for prolonged periods of time daily can kill you slowly.  

                SEE ALSO: The 9 Highest Paying Fitness Jobs

                Since you obviously can’t take a different career path to stay fit, you have to ensure that you don’t let your job stop you from staying active. If you don’t know how to begin, here are seven tips that are sure to help."
                };
                this.AddVotes(exercise13);
                categoryShoulders.Exercises.Add(exercise13);

                Exercise exercise14 = new Exercise
                {
                    Title = "Get More Out of Your Lateral Raises ",
                    Author = this.UsersCollection["user6@site.com"],
                    AuthorId = this.UsersCollection["user6@site.com"].Id,
                    Content = @"There are some things in your training regimen you do because, well, everybody does them. Everyone benches for a big chest, and if you want big legs, you squat. But sometimes the masses seem more like lemmings -- they aren't sure what or why they're doing something. They just do it because they believe they should, which brings us to the dumbbell lateral raise. Just about anyone who does this exercise raises the weights to only shoulder level, arms about parallel to the floor, but no higher. Know why? Think it causes rotator-cuff impingement and is dangerous to go above that point? Uh-uh. Think the arms-parallel position is where the middle delt stops working?

                Wrong again."
                };
                this.AddVotes(exercise14);
                categoryShoulders.Exercises.Add(exercise14);

                Exercise exercise15 = new Exercise
                {
                    Title = " 2 Best Methods to Build a Sexy V-Taper  ",
                    Author = this.UsersCollection["user6@site.com"],
                    AuthorId = this.UsersCollection["user6@site.com"].Id,
                    Content = @"KEY MOVES

                    For shoulders: Leaning one-arm side lateral raise, behind-the-back one-arm cable lateral.
                    For back: Straight-arm rope pulldown, wide-grip chinup.
                    For quads: Single-leg press, narrow-stance hack squat (add a pulse or half rep at the bottom).
                    For waist: Ab vacuum.

                TRAINING NOTES

                “The key to creating that V-taper look is to work on rounding out your shoulders, widening your lats, keeping a lean, tight waistline, and getting a bigger quad sweep. If you can keep your abs at least somewhat visible you are able to achieve that look year-round. But for that tight waist, your diet needs to be 90% perfect in the off-season. Focus on keeping your diet clean and eating carbs around your workout so your muscles can best utilize them.” "
                };
                this.AddVotes(exercise15);
                categoryShoulders.Exercises.Add(exercise15);
                context.Categories.Add(categoryShoulders);
                context.SaveChanges();

                // ===========================================================================
                var categoryPress = new Category()
                {
                    Name = "Press",
                    IsVisible = true
                };
                Exercise exercise1 = new Exercise
                {
                    Title = "Instant Muscle: Press Pain Free",
                    Author = this.UsersCollection["user1@site.com"],
                    AuthorId = this.UsersCollection["user1@site.com"].Id,
                    Content = @"Perform the exercises as a circuit, completing one set of each in sequence without rest in between. Afterward, rest 30 seconds and repeat for six to eight total circuits. Each time through, change your hand position slightly on the press, shrug, and pushup. For example, start with a shoulder-width grip on all three, then move it out an inch on subsequent sets.

SEE ALSO: The Anywhere 28-Day Circuit Workout

Set up spotter bars in a power rack so that after you shrug you can place the bar on the rack at waist height and do your pushups on the bar from there.
Quick Tips

The warmup may fatigue you so that you can’t train as heavy during your session. That’s OK—it’s a sign you need to improve your work capacity.

Performing lighter versions of the lifts you’ll do in your workout, or for very low reps so they’re not taxing, prepares the muscles and joints for the ranges of motion you’ll use in the workout as specifically as possible.
"
                };
                this.AddVotes(exercise1);
                categoryPress.Exercises.Add(exercise1);
                context.Categories.Add(categoryPress);
                context.SaveChanges();
            }
        }
    }
}
