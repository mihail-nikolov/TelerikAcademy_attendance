using SchoolSystem.Framework.Core.Commands.Contracts;
using System;

namespace SchoolSystem.Framework.Core.Commands
{
    public class CommandFactory : ICommandFactory
    {
        public ICommand GetCommand(string commandName)
        {
            switch (commandName)
            {
                case "CreateStudent":
                    return new CreateStudentCommand();
                case "CreateTeacher":
                    return new CreateTeacherCommand();
                case "RemoveStudent":
                    return new RemoveStudentCommand();
                case "RemoveTeacher":
                    return new RemoveTeacherCommand();
                case "StudentListMarks":
                    return new StudentListMarksCommand();
                case "TeacherAddMark":
                    return new TeacherAddMarkCommand();

                default:
                    throw new ArgumentException("The passed command is not found!");
            }
        }
    }
}
