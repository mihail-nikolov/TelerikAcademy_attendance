using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SchoolClasses
{
    public class SchoolClass
    {
        private List<Student> students;
        private List<Teacher> teachers;
        private string id;
        public SchoolClass(string id)
        {
            this.Students = new List<Student> { };
            this.Teachers = new List<Teacher> { };
            this.ID = id;        
        }
        public List<Student> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }
        public List<Teacher> Teachers
        {
            get { return this.teachers; }
            set { this.teachers = value; }
        }
        public string ID
        {
            get { return this.id; }
            set { this.id = value; }
        }
    }
}
