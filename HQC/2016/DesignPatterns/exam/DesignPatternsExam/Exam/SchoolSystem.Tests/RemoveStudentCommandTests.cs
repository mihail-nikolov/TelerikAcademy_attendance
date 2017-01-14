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
    public class RemoveStudentCommandTests
    {
        [Test]
        public void Execute_RemoveStudentCorrectly()
        {
            List<string> parameters = new List<string>
            {
                "Pesho", "Peshev", "11"
            };

            var mockedStudentFactory = new Mock<IStudentFactory>();
            var mockedTeacherFactory = new Mock<ITeacherFactory>();
            var mockedMarkFactory = new Mock<IMarkFactory>();
            var school = new School();
            var student = new Student("Pesho", "Peshev", Grade.Eleventh);

            mockedStudentFactory.Setup(x => x.CreateStudent("Pesho", "Peshev", Grade.Eleventh)).Returns(student);

            CreateStudentCommand createCommand = new CreateStudentCommand();
            string answer = createCommand.Execute(parameters, school, mockedStudentFactory.Object, mockedTeacherFactory.Object, mockedMarkFactory.Object);

            // assert student created
            Assert.IsTrue(answer.Contains("A new student with name Pesho Peshev, grade Eleventh and ID"));

            RemoveStudentCommand removeCommand = new RemoveStudentCommand();
            List<string> removeParameters = new List<string>
            {
                "0"
            };

            var removeAnswer = removeCommand.Execute(removeParameters, school, mockedStudentFactory.Object, mockedTeacherFactory.Object, mockedMarkFactory.Object);

            Assert.IsTrue(removeAnswer.Contains("Student with ID 0 was sucessfully removed."));
            Assert.That(() => school.GetStudent(0), Throws.ArgumentException.With.Message.Contains("The given key was not present in the dictionary."));
        }

        [Test]
        public void Execute_ShouldThrowArgumentException_WhenNonExistingStudent()
        {
            List<string> parameters = new List<string>
            {
                "Pesho", "Peshev", "11"
            };

            var mockedStudentFactory = new Mock<IStudentFactory>();
            var mockedTeacherFactory = new Mock<ITeacherFactory>();
            var mockedMarkFactory = new Mock<IMarkFactory>();
            var school = new School();
            var student = new Student("Pesho", "Peshev", Grade.Eleventh);

            RemoveStudentCommand removeCommand = new RemoveStudentCommand();
            List<string> removeParameters = new List<string>
            {
                "0"
            };

            Assert.That(() => removeCommand.Execute(removeParameters, school, mockedStudentFactory.Object, mockedTeacherFactory.Object, mockedMarkFactory.Object), 
                Throws.ArgumentException.With.Message.Contains("The given key was not present in the dictionary."));
        }
    }
}
