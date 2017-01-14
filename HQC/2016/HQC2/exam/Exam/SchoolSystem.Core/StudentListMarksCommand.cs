namespace SchoolSystem.Core
{
    using System.Collections.Generic;
    using Contracts;
    using Models.Contracts;

    public class StudentListMarksCommand : Command, ICommand
    {
        public override string Execute(IList<string> parameters, ISchool school)
        {
            int studentId = int.Parse(parameters[0]);
            var student = school.GetStudent(studentId);

            var marks = student.ListMarks();

            return marks;
        }
    }
}
