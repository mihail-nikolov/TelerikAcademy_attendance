namespace SchoolSystem.Tests
{
    using Framework.Core;
    using Framework.Core.Commands;
    using Framework.Core.Contracts;
    using Framework.Models;
    using Framework.Models.Enums;
    using Moq;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class CreateStudentCommandTests
    {
        [Test]
        public void Execute_ShouldCreateStudentCorrectly()
        {
            List<string> parameters = new List<string>
            {
                "Pesho", "Peshev", "11"
            };

            var mockedStudentFactory = new Mock<IStudentFactory>();
            var mockedTeacherFactory = new Mock<ITeacherFactory>();
            var mockedMarkFactory = new Mock<IMarkFactory>();

            var student = new Student("Pesho", "Peshev", Grade.Eleventh);

            mockedStudentFactory.Setup(x => x.CreateStudent("Pesho", "Peshev", Grade.Eleventh)).Returns(student);

            var school = new School();

            CreateStudentCommand command = new CreateStudentCommand();
            string answer = command.Execute(parameters, school, mockedStudentFactory.Object, mockedTeacherFactory.Object, mockedMarkFactory.Object);

            Assert.IsTrue(answer.Contains("A new student with name Pesho Peshev, grade Eleventh and ID"));
            mockedStudentFactory.VerifyAll();

            var createdStudent = school.GetStudent(0);
            Assert.AreSame(createdStudent, student);
        }
    }
}
