namespace FitnessSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Common.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Exercise> Exercises { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Vote> Votes { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Feedback> Feedbacks { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
              .Entity<Exercise>()
              .HasRequired(p => p.Category)
              .WithMany(x => x.Exercises)
              .WillCascadeOnDelete(true);

            modelBuilder
              .Entity<Exercise>()
              .HasRequired(p => p.Author)
              .WithMany(x => x.Exercises)
              .WillCascadeOnDelete(false);

            modelBuilder
              .Entity<Comment>()
              .HasRequired(p => p.Exercise)
              .WithMany(x => x.Comments)
              .WillCascadeOnDelete(true);

            modelBuilder
              .Entity<Comment>()
              .HasRequired(p => p.Author)
              .WithMany(x => x.Comments)
              .WillCascadeOnDelete(false);

            modelBuilder
              .Entity<Vote>()
              .HasRequired(p => p.Exercise)
              .WithMany(x => x.Votes)
              .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
