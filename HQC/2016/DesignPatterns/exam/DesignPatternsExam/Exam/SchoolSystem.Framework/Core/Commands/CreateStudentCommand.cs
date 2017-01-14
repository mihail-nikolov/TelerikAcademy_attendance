using System.Collections.Generic;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Models.Enums;
using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Framework.Core.Commands
{
    public class CreateStudentCommand : ICommand
    {
        public string Execute(IList<string> parameters, ISchool school, IStudentFactory studentFactory, ITeacherFactory teacherFactory, IMarkFactory markFactory)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var grade = (Grade)int.Parse(parameters[2]);

            var student = studentFactory.CreateStudent(firstName, lastName, grade);
            school.AddStudent(student);

            return $"A new student with name {firstName} {lastName}, grade {grade} and ID {school.GetLastStudentId - 1} was created.";
        }
    }
}
