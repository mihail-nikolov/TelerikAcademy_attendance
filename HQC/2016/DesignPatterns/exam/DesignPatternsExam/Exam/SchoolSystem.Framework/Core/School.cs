namespace SchoolSystem.Framework.Core
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Models.Contracts;

    public class School : ISchool
    {
        private const string KeyNotFound = "The given key was not present in the dictionary.";

        private Dictionary<int, IStudent> students;
        private Dictionary<int, ITeacher> teachers;
        private int teacherId = 0;
        private int studentId = 0;

        public School()
        {
            this.students = new Dictionary<int, IStudent>();
            this.teachers = new Dictionary<int, ITeacher>();
            this.teacherId = 0;
            this.studentId = 0;
        }

        public int GetLastTeacherId
        {
            get
            {
                return this.teacherId;
            }
        }

        public int GetLastStudentId
        {
            get
            {
                return this.studentId;
            }
        }

        public ITeacher GetTeacher(int id)
        {
            if (!this.teachers.ContainsKey(id))
            {
                throw new ArgumentException(KeyNotFound);
            }

            return this.teachers[id];
        }

        public void AddTeacher(ITeacher teacher)
        {
            this.teachers.Add(this.teacherId, teacher);
            this.teacherId++;
        }

        public void RemoveTeacher(int id)
        {
            if (!this.teachers.ContainsKey(id))
            {
                throw new ArgumentException(KeyNotFound);
            }

            this.teachers.Remove(id);
        }

        public IStudent GetStudent(int id)
        {
            if (!this.students.ContainsKey(id))
            {
                throw new ArgumentException(KeyNotFound);
            }
            return this.students[id];
        }

        public void AddStudent(IStudent student)
        {
            this.students.Add(this.studentId, student);
            this.studentId++;
        }

        public void RemoveStudent(int id)
        {
            if (!this.students.ContainsKey(id))
            {
                throw new ArgumentException(KeyNotFound);
            }

            this.students.Remove(id);
        }
    }
}
