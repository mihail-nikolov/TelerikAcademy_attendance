namespace SchoolSystem.Core
{
    using System.Collections.Generic;
    using Contracts;
    using Models.Contracts;

    public class RemoveStudentCommand : Command, ICommand
    {
        public override string Execute(IList<string> parameters, ISchool school)
        {
            int studentId = int.Parse(parameters[0]);
            school.RemoveStudent(studentId);

            return $"Student with ID {studentId} was sucessfully removed.";
        }
    }
}
