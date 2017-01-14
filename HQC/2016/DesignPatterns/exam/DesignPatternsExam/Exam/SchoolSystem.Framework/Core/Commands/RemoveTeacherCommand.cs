using System.Collections.Generic;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Framework.Core.Commands
{
    public class RemoveTeacherCommand : ICommand
    {
        public string Execute(IList<string> parameters, ISchool school, IStudentFactory studentFactory, ITeacherFactory teacherFactory, IMarkFactory markFactory)
        {
            var teacherId = int.Parse(parameters[0]);

            school.RemoveTeacher(teacherId);
            return $"Teacher with ID {teacherId} was sucessfully removed.";
        }
    }
}
