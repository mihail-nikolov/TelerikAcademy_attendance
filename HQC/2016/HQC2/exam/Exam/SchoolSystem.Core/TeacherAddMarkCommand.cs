namespace SchoolSystem.Core
{
    using System.Collections.Generic;
    using Contracts;
    using Models.Contracts;

    public class TeacherAddMarkCommand : Command, ICommand
    {
        public override string Execute(IList<string> parameters, ISchool school)
        {
            var teacherId = int.Parse(parameters[0]);
            var studentId = int.Parse(parameters[1]);

            var teacher = school.GetTeacher(teacherId);
            var student = school.GetStudent(studentId);

            float mark = float.Parse(parameters[2]);
            teacher.AddMark(student, mark);

            return $"Teacher {teacher.FirstName} {teacher.LastName} added mark {mark} to student {student.FirstName} {student.LastName} in {teacher.Subject}.";
        }
    }
}
