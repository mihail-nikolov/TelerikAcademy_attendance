namespace SchoolSystem.Tests
{
    using Framework.Core.Commands;
    using Framework.Core.Contracts;
    using Framework.Models;
    using Framework.Models.Enums;
    using Moq;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class TeacherAddMarkCommandTests
    {
        [Test]
        public void Execute_AddMarkCorrectly()
        {
            List<string> parameters = new List<string>
            {
                "1", "1", "5"
            };

            var mockedStudentFactory = new Mock<IStudentFactory>();
            var mockedTeacherFactory = new Mock<ITeacherFactory>();
            var mockedMarkFactory = new Mock<IMarkFactory>();
            var mockedSchool = new Mock<ISchool>();

            var student = new Student("Gosho", "Petrov", Grade.Fifth);
            var teacher = new Teacher("Stamat", "Shop", Subject.English);
            var mark = new Mark(teacher.Subject, 5);

            mockedSchool.Setup(x => x.GetStudent(1)).Returns(student);
            mockedSchool.Setup(x => x.GetTeacher(1)).Returns(teacher);
            mockedMarkFactory.Setup(x => x.CreateMark(teacher.Subject, 5)).Returns(mark);

            TeacherAddMarkCommand command = new TeacherAddMarkCommand();
            string answer = command.Execute(parameters, mockedSchool.Object, mockedStudentFactory.Object, mockedTeacherFactory.Object, mockedMarkFactory.Object);

            Assert.IsTrue(answer.Contains("Teacher Stamat Shop added mark 5 to student Gosho Petrov in English."));
            var createdMark = student.Marks[0];
            Assert.AreSame(createdMark, mark);
            mockedMarkFactory.VerifyAll();
            mockedSchool.VerifyAll();
        }

        [Test]
        public void Execute_ShouldThrowArgumentException_WhenMoreThanTwentyMarks()
        {
            List<string> parameters = new List<string>
            {
                "1", "1", "5"
            };

            var mockedStudentFactory = new Mock<IStudentFactory>();
            var mockedTeacherFactory = new Mock<ITeacherFactory>();
            var mockedMarkFactory = new Mock<IMarkFactory>();
            var mockedSchool = new Mock<ISchool>();

            var student = new Student("Gosho", "Petrov", Grade.Fifth);
            var teacher = new Teacher("Stamat", "Shop", Subject.English);
            var mark = new Mark(teacher.Subject, 5);

            for (int i = 0; i < 20; i++)
            {
                teacher.AddMark(student, mark);
            }

            mockedSchool.Setup(x => x.GetStudent(1)).Returns(student);
            mockedSchool.Setup(x => x.GetTeacher(1)).Returns(teacher);
            mockedMarkFactory.Setup(x => x.CreateMark(teacher.Subject, 5)).Returns(mark);

            TeacherAddMarkCommand command = new TeacherAddMarkCommand();

            Assert.That(() => command.Execute(parameters, mockedSchool.Object, mockedStudentFactory.Object, mockedTeacherFactory.Object, mockedMarkFactory.Object),
                Throws.ArgumentException.With.Message.Contains("The student's marks count exceed the maximum count of 20 marks"));

            mockedMarkFactory.VerifyAll();
            mockedSchool.VerifyAll();
        }
    }
}
