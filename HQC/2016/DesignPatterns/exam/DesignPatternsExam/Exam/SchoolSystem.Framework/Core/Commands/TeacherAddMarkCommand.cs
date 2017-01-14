using System.Collections.Generic;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Models;

namespace SchoolSystem.Framework.Core.Commands
{
    public class TeacherAddMarkCommand : ICommand
    {
        public string Execute(IList<string> parameters, ISchool school, IStudentFactory studentFactory, ITeacherFactory teacherFactory, IMarkFactory markFactory)
        {
            var teacherId = int.Parse(parameters[0]);
            var studentId = int.Parse(parameters[1]);
            var mark = float.Parse(parameters[2]);
            
            var student = school.GetStudent(studentId);
            var teacher = school.GetTeacher(teacherId);

            Mark martToAdd = markFactory.CreateMark(teacher.Subject, mark);

            teacher.AddMark(student, martToAdd);
            return $"Teacher {teacher.FirstName} {teacher.LastName} added mark {mark} to student {student.FirstName} {student.LastName} in {teacher.Subject}.";
        }
    }
}
