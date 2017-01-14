namespace SchoolSystem.Tests
{
    using Models;
    using Models.Enums;
    using NUnit.Framework;

    [TestFixture]
    public class StudentTests
    {
        [Test]
        public void Contructor_ShouldThrowArgumentExceptionWhenFirstNameLowerThanTwo()
        {
            var firstName = "g";
            var lastName = "gosho";
            Grade grade = Grade.Eighth;

            Assert.That(() => new Student(firstName, lastName, grade), Throws.ArgumentException.With.Message.Contains("Name length should be in interval"));
        }

        [Test]
        public void Contructor_ShouldThrowArgumentExceptionWhenFirstNameHigherThan31()
        {
            var firstName = "assdaffsdfzsfzsdfszzsdgzsdzbgsdvzsdvzsdvszdvsdvzsvdszdzsv";
            var lastName = "gosho";
            Grade grade = Grade.Eighth;

            Assert.That(() => new Student(firstName, lastName, grade), Throws.ArgumentException.With.Message.Contains("Name length should be in interval"));
        }

        [Test]
        public void Contructor_ShouldThrowArgumentExceptionWhenLastNameLowerThanTwo()
        {
            var firstName = "gosho";
            var lastName = "g";
            Grade grade = Grade.Eighth;

            Assert.That(() => new Student(firstName, lastName, grade), Throws.ArgumentException.With.Message.Contains("Name length should be in interval"));
        }

        [Test]
        public void Contructor_ShouldThrowArgumentExceptionWhenLastNameHigherThan31()
        {
            var firstName = "gosho";
            var lastName = "assdaffsdfzsfzsdfszzsdgzsdzbgsdvzsdvzsdvszdvsdvzsvdszdzsv";
            Grade grade = Grade.Eighth;

            Assert.That(() => new Student(firstName, lastName, grade), Throws.ArgumentException.With.Message.Contains("Name length should be in interval"));
        }

        [Test]
        public void Contructor_ShouldSetPropertiesCorrectlyAndShouldIncreaseIdWhenNewAdded()
        {
            var firstName = "gosho";
            var lastName = "goshev";
            Grade grade = Grade.Eighth;

            var student = new Student(firstName, lastName, grade);

            Assert.AreEqual(student.FirstName, firstName);
            Assert.AreEqual(student.LastName, lastName);
            Assert.AreEqual(student.Grade, grade);
            Assert.AreEqual(student.Id, 0);

            var newStudent = new Student(firstName, lastName, grade);

            Assert.AreEqual(newStudent.Id, 1);
        }

        [Test]
        public void ListMarks_ShouldReturn_NoMarks_WhenNoAdded()
        {
            var firstName = "gosho";
            var lastName = "goshev";
            Grade grade = Grade.Eighth;

            var student = new Student(firstName, lastName, grade);

            string hasNoMarksMessage = "This student has no marks.";
            string answer = student.ListMarks();
            Assert.AreEqual(answer, hasNoMarksMessage);
        }

        [Test]
        public void ListMarks_ShouldListMarksCorrectly()
        {
            var firstName = "gosho";
            var lastName = "goshev";
            Grade grade = Grade.Eighth;

            var student = new Student(firstName, lastName, grade);

            var value = 6;
            Subject subject = Subject.Bulgarian;
            var mark = new Mark(subject, value);

            student.Marks.Add(mark);

            string listed = student.ListMarks();

            Assert.AreEqual("The student has these marks:\nBulgarian => 6\n", listed);
        }
    }
}
