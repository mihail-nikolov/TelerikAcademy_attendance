namespace SchoolSystem.Tests
{
    using Models;
    using Models.Enums;
    using NUnit.Framework;

    [TestFixture]
    public class TeacherTests
    {
        [Test]
        public void Contructor_ShouldThrowArgumentExceptionWhenFirstNameLowerThanTwo()
        {
            var firstName = "g";
            var lastName = "gosho";
            Subject subject = Subject.Bulgarian;

            Assert.That(() => new Teacher(firstName, lastName, subject), Throws.ArgumentException.With.Message.Contains("Name length should be in interval"));
        }

        [Test]
        public void Contructor_ShouldThrowArgumentExceptionWhenFirstNameHigherThan31()
        {
            var firstName = "assdaffsdfzsfzsdfszzsdgzsdzbgsdvzsdvzsdvszdvsdvzsvdszdzsv";
            var lastName = "gosho";
            Subject subject = Subject.Bulgarian;

            Assert.That(() => new Teacher(firstName, lastName, subject), Throws.ArgumentException.With.Message.Contains("Name length should be in interval"));
        }

        [Test]
        public void Contructor_ShouldThrowArgumentExceptionWhenLastNameLowerThanTwo()
        {
            var firstName = "gosho";
            var lastName = "g";
            Subject subject = Subject.Bulgarian;

            Assert.That(() => new Teacher(firstName, lastName, subject), Throws.ArgumentException.With.Message.Contains("Name length should be in interval"));
        }

        [Test]
        public void Contructor_ShouldThrowArgumentExceptionWhenLastNameHigherThan31()
        {
            var firstName = "gosho";
            var lastName = "assdaffsdfzsfzsdfszzsdgzsdzbgsdvzsdvzsdvszdvsdvzsvdszdzsv";
            Subject subject = Subject.Bulgarian;

            Assert.That(() => new Teacher(firstName, lastName, subject), Throws.ArgumentException.With.Message.Contains("Name length should be in interval"));
        }

        [Test]
        public void Contructor_ShouldSetPropertiesCorrectlyAndShouldIncreaseIdWhenNewAdded()
        {
            var firstName = "gosho";
            var lastName = "goshev";
            Subject subject = Subject.Bulgarian;

            var teacher = new Teacher(firstName, lastName, subject);

            Assert.AreEqual(teacher.FirstName, firstName);
            Assert.AreEqual(teacher.LastName, lastName);
            Assert.AreEqual(teacher.Subject, subject);
            Assert.AreEqual(teacher.Id, 0);

            var newTeacher = new Teacher(firstName, lastName, subject);

            Assert.AreEqual(newTeacher.Id, 1);
        }

        [Test]
        public void AddMark_ShouldAddTheMarkToStudentCorrectly()
        {
            var firstNameTeacher = "petar";
            var lastNameTeacher = "petrov";
            Subject subject = Subject.Bulgarian;
            var teacher = new Teacher(firstNameTeacher, lastNameTeacher, subject);

            var firstNameStudent = "gosho";
            var lastNameStudent = "goshev";
            Grade grade = Grade.Eighth;
            var student = new Student(firstNameStudent, lastNameStudent, grade);

            var value = 6;
            teacher.AddMark(student, value);

            Assert.AreEqual(student.Marks[0].Subject, subject);
            Assert.AreEqual(student.Marks[0].Value, value);
        }
    }
}
