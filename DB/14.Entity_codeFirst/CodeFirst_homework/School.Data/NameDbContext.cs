using School.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Data
{
    public class NameDbContext : DbContext
    {
        public NameDbContext() :
            base("SchoolDbConnection") 
        { 
        }
        public IDbSet<Student> Students { get; set; }
        public IDbSet<Course> Courses { get; set; }
        public IDbSet<Homework> Homeworks { get; set; } 
    }
}
