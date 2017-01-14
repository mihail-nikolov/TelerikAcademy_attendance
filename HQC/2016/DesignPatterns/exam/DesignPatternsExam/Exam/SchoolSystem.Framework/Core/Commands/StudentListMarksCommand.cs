using System.Collections.Generic;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Framework.Core.Commands
{
    public class StudentListMarksCommand : ICommand
    {
        public string Execute(IList<string> parameters, ISchool school, IStudentFactory studentFactory, ITeacherFactory teacherFactory, IMarkFactory markFactory)
        {
            var studentId = int.Parse(parameters[0]);
            var student = school.GetStudent(studentId);
            return student.ListMarks();
        }
    }
}
