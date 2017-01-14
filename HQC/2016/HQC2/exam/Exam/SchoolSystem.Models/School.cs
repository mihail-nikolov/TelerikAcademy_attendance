namespace SchoolSystem.Models
{
    using System;
    using System.Collections.Generic;
    using SchoolSystem.Models.Contracts;

    public class School : ISchool
    {
        private const string CouldNotFindPerson = "could not find {0} with ID: {1}";

        private Dictionary<int, Student> students;
        private Dictionary<int, Teacher> teachers;

        public School()
        {
            this.students = new Dictionary<int, Student>();
            this.teachers = new Dictionary<int, Teacher>();
        }

        public Teacher GetTeacher(int id)
        {
            return this.teachers[id];
        }

        public void AddTeacher(int id, Teacher teacher)
        {
            this.teachers.Add(id, teacher);
        }

        public void RemoveTeacher(int id)
        {
            if (!this.teachers.ContainsKey(id))
            {
                string errorMessage = string.Format(CouldNotFindPerson, "teacher", id);
                throw new ArgumentException(errorMessage);
            }

            this.teachers.Remove(id);
        }

        public Student GetStudent(int id)
        {
            return this.students[id];
        }

        public void AddStudent(int id, Student student)
        {
            this.students.Add(id, student);
        }

        public void RemoveStudent(int id)
        {
            if (!this.students.ContainsKey(id))
            {
                string errorMessage = string.Format(CouldNotFindPerson, "student", id);
                throw new ArgumentException(errorMessage);
            }

            this.students.Remove(id);
        }
    }
}
