namespace School.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Materials = c.String(),
                        HomeWorkId = c.Int(nullable: false),
                        Student_StudentId = c.Int(),
                        Student_StudentId1 = c.Int(),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.Homework", t => t.HomeWorkId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_StudentId)
                .ForeignKey("dbo.Students", t => t.Student_StudentId1)
                .Index(t => t.HomeWorkId)
                .Index(t => t.Student_StudentId)
                .Index(t => t.Student_StudentId1);
            
            CreateTable(
                "dbo.Homework",
                c => new
                    {
                        HomeworkId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        TimeSent = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HomeworkId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Number = c.Int(nullable: false),
                        HomeWorkId = c.Int(nullable: false),
                        Course_CourseId = c.Int(),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Homework", t => t.HomeWorkId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_CourseId)
                .Index(t => t.HomeWorkId)
                .Index(t => t.Course_CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Course_CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "Student_StudentId1", "dbo.Students");
            DropForeignKey("dbo.Students", "HomeWorkId", "dbo.Homework");
            DropForeignKey("dbo.Courses", "Student_StudentId", "dbo.Students");
            DropForeignKey("dbo.Courses", "HomeWorkId", "dbo.Homework");
            DropIndex("dbo.Students", new[] { "Course_CourseId" });
            DropIndex("dbo.Students", new[] { "HomeWorkId" });
            DropIndex("dbo.Courses", new[] { "Student_StudentId1" });
            DropIndex("dbo.Courses", new[] { "Student_StudentId" });
            DropIndex("dbo.Courses", new[] { "HomeWorkId" });
            DropTable("dbo.Students");
            DropTable("dbo.Homework");
            DropTable("dbo.Courses");
        }
    }
}
