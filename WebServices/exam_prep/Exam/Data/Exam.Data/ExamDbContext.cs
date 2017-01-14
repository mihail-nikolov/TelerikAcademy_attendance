namespace Exam.Data
{
    using Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    public class ExamDbContext : IdentityDbContext<User>, IExamDbContext
    {
        public ExamDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ExamDbContext Create()
        {
            return new ExamDbContext();
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
            
        //    base.OnModelCreating(modelBuilder);
        //}
        //use if do not want to remove require fields
    }
}
