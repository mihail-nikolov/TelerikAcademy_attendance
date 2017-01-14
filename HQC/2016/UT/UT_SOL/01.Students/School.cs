using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Students
{
    public class School
    {
        private string name;
        private List<Student> studentsInSchool = new List<Student> { };

        public School(string name)
        {
            this.Name = name;
        }
        public List<Student> StudentsInSchool
        {
            get { return this.studentsInSchool; }
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (value == "")
                {
                    throw new ArgumentException("empty string!");
                }
                this.name = value;
            }
        }
        private bool isStudentInSchool(Student student)
        {
            foreach (var stInSchool in this.studentsInSchool)
            {
                if (stInSchool.UniqueNumber == student.UniqueNumber)
                {
                    return true;
                }
            }
            return false;
        }

        public void Add(Student student)
        {
            if (isStudentInSchool(student) == true)
            {
                throw new ArgumentException("student is in this course");
            }
            this.studentsInSchool.Add(student);
        }
        public void Remove(Student student)
        {
            if (isStudentInSchool(student) == false)
            {
                throw new ArgumentException("student not in this course");
            }
            foreach (var stInSchool in this.studentsInSchool)
            {
                if (stInSchool.UniqueNumber == student.UniqueNumber)
                {
                    this.studentsInSchool.Remove(student);
                    break;
                }
            }
        }
    }
}
