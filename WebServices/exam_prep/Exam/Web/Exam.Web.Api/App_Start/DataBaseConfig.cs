namespace Exam.Web.Api.App_Start
{
    using Exam.Data;
    using Exam.Data.Migrations;
    using System.Data.Entity;

    public static class DataBaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ExamDbContext, Configuration>());
        }
    }
}   