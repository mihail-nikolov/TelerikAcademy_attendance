namespace SchoolSystem.Tests
{
    using NUnit.Framework;
    using Moq;
    using Core;
    using Core.Contracts;
    using Models.Contracts;
    using Models;
    using Models.Enums;
    [TestFixture]
    public class EngineTests
    {
        [Test]
        public void Contructor_ShouldSetPropertiesCorrectly()
        {
            var mockedReader = new Mock<IReader>();
            var mockedWriter = new Mock<IWriter>();
            var mockedSchool = new Mock<ISchool>();

            var engine = new Engine(mockedReader.Object, mockedWriter.Object, mockedSchool.Object);
            mockedReader.VerifyAll();
            mockedWriter.VerifyAll();
            mockedSchool.VerifyAll();
        }

        // this 2 are working but has threading issues with another test => should be run separately

        //[Test]
        //public void Run_ShouldInvokeCreateStudentCommand()
        //{
        //    var mockedWriter = new Mock<IWriter>();
        //    var mockedSchool = new Mock<ISchool>();
        //    var mockedReader = new MockedReader("CreateStudent Pesho Peshev 11");

        //    var student = new Student("Pesho", "Peshev", (Grade)11);
        //    mockedSchool.Setup(x => x.AddStudent(student.Id, student));
        //    mockedWriter.Setup(x => x.WriteLine("A new student with name Pesho Peshev, grade Eleventh and ID 1 was created."));

        //    var engine = new Engine(mockedReader, mockedWriter.Object, mockedSchool.Object);
        //    engine.Run();

        //    mockedWriter.Verify(x => x.WriteLine("A new student with name Pesho Peshev, grade Eleventh and ID 1 was created."), Times.Once);
        //}

        //[Test]
        //public void Run_ShouldInvokeCreateTeacherCommand()
        //{
        //    var mockedWriter = new Mock<IWriter>();
        //    var mockedSchool = new Mock<ISchool>();
        //    var mockedReader = new MockedReader("CreateTeacher Gosho Vesheff 2");

        //    var firstName = "Gosho";
        //    var lastName = "Vesheff";
        //    Subject subject = Subject.Math;

        //    var teacher = new Teacher(firstName, lastName, subject);

        //    mockedSchool.Setup(x => x.AddTeacher(teacher.Id, teacher));
        //    mockedWriter.Setup(x => x.WriteLine("A new teacher with name Gosho Vesheff, subject Math and ID 0 was created."));

        //    var engine = new Engine(mockedReader, mockedWriter.Object, mockedSchool.Object);
        //    engine.Run();

        //    mockedWriter.Verify(x => x.WriteLine("A new teacher with name Gosho Vesheff, subject Math and ID 0 was created."), Times.Once);
        //}

        [Test]
        public void Run_ShouldThrowException_WhenUnkownCommand()
        {
            var mockedWriter = new Mock<IWriter>();
            string errorMessage = "The passed command is not found!";
            mockedWriter.Setup(x => x.WriteLine(errorMessage));
            var mockedSchool = new Mock<ISchool>();
            var mockedReader = new MockedReader("CreateGosho Pesho Peshev 11");

            var engine = new Engine(mockedReader, mockedWriter.Object, mockedSchool.Object);

            engine.Run();

            mockedWriter.Verify(x => x.WriteLine(errorMessage), Times.Once);
        }

        [Test]
        public void Run_ShouldBreakWhenEnd()
        {
            var mockedReader = new Mock<IReader>();
            var mockedWriter = new Mock<IWriter>();
            var mockedSchool = new Mock<ISchool>();

            var engine = new Engine(mockedReader.Object, mockedWriter.Object, mockedSchool.Object);

            mockedReader.Setup(x => x.Read()).Returns("End");

            engine.Run();
            mockedReader.Verify(x => x.Read(), Times.Once);
        }
    }
}
