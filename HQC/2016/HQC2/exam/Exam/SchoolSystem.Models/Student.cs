namespace SchoolSystem.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Enums;

    public class Student : Person
    {
        private static int studentsId = 0;

        public Student(string firstName, string lastName, Grade grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
            this.Marks = new List<Mark>();
            this.SetId();
        }

        public Grade Grade { get; private set; }

        public List<Mark> Marks { get; private set; }

        public string ListMarks()
        {
            string hasNoMarksMessage = "This student has no marks.";
            if (this.Marks.Count == 0)
            {
                return hasNoMarksMessage;
            }

            string header = "The student has these marks:";
            var marks = this.Marks.Select(m => $"{m.Subject} => {m.Value}").ToList();

            string answer = header + "\n" + string.Join("\n", marks) + "\n";

            return answer;
        }

        protected override void SetId()
        {
            this.Id = studentsId;
            studentsId++;
        }
    }
}
