using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Students
{
    public class Course
    {
        private string name;
        private List<Student> studentsInCourse = new List<Student> { };
        private const int MAX_STUDENTS_IN_COURSE = 30;

        public Course(string name)
        {
            this.Name = name;
        }
        public List<Student> StudentsInCourse
        {
            get { return this.studentsInCourse; }
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

        private bool isStudentInCourse(Student student)
        {
            foreach (var stInCourse in this.studentsInCourse)
            {
                if (stInCourse.UniqueNumber == student.UniqueNumber)
                {
                    return true;
                }
            }
            return false; 
        }

        public void Add(Student student)
        {
            if (this.studentsInCourse.Count >= MAX_STUDENTS_IN_COURSE)
            {
                throw new ArgumentException("students is in this course should be <=30");
            }
            if (isStudentInCourse(student) == true)
            {
                throw new ArgumentException("student is in this course");
            }
            this.studentsInCourse.Add(student);
        }
        public void Remove(Student student)
        {
            if (isStudentInCourse(student) == false)
            {
                throw new ArgumentException("student not in this course");
            }
            foreach (var stInCourse in this.studentsInCourse)
            {
                if (stInCourse.UniqueNumber == student.UniqueNumber)
                {
                    this.studentsInCourse.Remove(student);
                    break;
                }
            }
        }

    }
}
