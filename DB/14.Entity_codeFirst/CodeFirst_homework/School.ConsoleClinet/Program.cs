using School.Data;
using School.Data.Migrations;
using School.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.ConsoleClinet
{
    class Program
    {
        static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NameDbContext, Configuration>());

            var db = new NameDbContext();
            var baihui = new Student()
            {
                Name = "baihui"
            };

            db.Students.Add(baihui);

            var baihui2 = new Student()
            {
                Name = "baihui2"
            };

            db.Students.Add(baihui2);
            db.SaveChanges();
            //db.Database.CreateIfNotExists();//run this if you want just to create the DB and tables
        }
    }
}
