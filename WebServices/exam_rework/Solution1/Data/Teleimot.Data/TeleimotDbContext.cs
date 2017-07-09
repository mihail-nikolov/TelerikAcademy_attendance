namespace Teleimot.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Contracts;
    using Models.BaseModels;

    public class TeleimotDbContext : IdentityDbContext<User>, ITeleimotDbContext
    {
        public TeleimotDbContext()
            : base("TeleimotDbRework", throwIfV1Schema: false)
        {
        }

        public static TeleimotDbContext Create()
        {
            return new TeleimotDbContext();
        }

        public IDbSet<Rating> Categories { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<RealEstate> RealEstates { get; set; }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().ToTable("AspNetUsers");

        //    base.OnModelCreating(modelBuilder);
        //}

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
