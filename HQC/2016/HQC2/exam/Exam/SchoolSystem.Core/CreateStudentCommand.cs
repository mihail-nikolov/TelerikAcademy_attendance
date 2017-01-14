namespace SchoolSystem.Core
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Models;
    using Models.Contracts;
    using Models.Enums;

    public class CreateStudentCommand : Command, ICommand
    {
        public override string Execute(IList<string> parameters, ISchool school)
        {
            string firstName = parameters[0];
            string lastName = parameters[1];
            Grade grade = (Grade)int.Parse(parameters[2]);
            var student = new Student(firstName, lastName, grade);

            school.AddStudent(student.Id, student);

            string gradeToString = Enum.GetName(typeof(Grade), student.Grade);

            return $"A new student with name {student.FirstName} {student.LastName}, grade {gradeToString} and ID {student.Id} was created.";
        }
    }
}
