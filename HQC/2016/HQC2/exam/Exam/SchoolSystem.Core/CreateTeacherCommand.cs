namespace SchoolSystem.Core
{
    using System.Collections.Generic;
    using Contracts;
    using Models;
    using Models.Contracts;
    using Models.Enums;

    public class CreateTeacherCommand : Command, ICommand
    {
        public override string Execute(IList<string> parameters, ISchool school)
        {
            string firstName = parameters[0];
            string lastName = parameters[1];
            Subject subject = (Subject)int.Parse(parameters[2]);
            var teacher = new Teacher(firstName, lastName, subject);

            school.AddTeacher(teacher.Id, teacher);

            return $"A new teacher with name {teacher.FirstName} {teacher.LastName}, subject {teacher.Subject} and ID {teacher.Id} was created.";
        }
    }
}
