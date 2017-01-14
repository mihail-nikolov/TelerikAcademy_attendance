using System.Collections.Generic;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Models.Enums;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Models.Contracts;

namespace SchoolSystem.Framework.Core.Commands
{
    public class CreateTeacherCommand : ICommand
    {
        public string Execute(IList<string> parameters, ISchool school, IStudentFactory studentFactory, ITeacherFactory teacherFactory, IMarkFactory markFactory)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var subject = (Subject)int.Parse(parameters[2]);

            ITeacher teacher = teacherFactory.CreateTeacher(firstName, lastName, subject);
            school.AddTeacher(teacher);

            return $"A new teacher with name {firstName} {lastName}, subject {subject} and ID {school.GetLastTeacherId - 1} was created.";
        }
    }
}
