namespace SchoolSystem.Core
{
    using System.Collections.Generic;
    using Contracts;
    using Models.Contracts;

    public class RemoveTeacherCommand : Command, ICommand
    {
        public override string Execute(IList<string> parameters, ISchool school)
        {
            int teacherId = int.Parse(parameters[0]);
            school.RemoveTeacher(teacherId);

            return $"Teacher with ID {teacherId} was sucessfully removed.";
        }
    }
}
