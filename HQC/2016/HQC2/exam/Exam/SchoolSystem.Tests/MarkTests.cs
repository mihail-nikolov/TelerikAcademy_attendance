namespace SchoolSystem.Tests
{
    using Models;
    using Models.Enums;
    using NUnit.Framework;

    [TestFixture]
    public class MarkTests
    {
        [Test]
        public void Contructor_ShouldThrowArgumentExceptionWhenValueLowerThanTwo()
        {
            var value = 1;
            Subject subject = Subject.Bulgarian;
            Assert.That(() => new Mark(subject, value), Throws.ArgumentException.With.Message.Contains("Value should be in interval"));
        }

        [Test]
        public void Contructor_ShouldThrowArgumentExceptionWhenValueHigherThanSix()
        {
            var value = 7;
            Subject subject = Subject.Bulgarian;
            Assert.That(() => new Mark(subject, value), Throws.ArgumentException.With.Message.Contains("Value should be in interval"));
        }

        [Test]
        public void Contructor_ShouldSetPropertiesCorrectly()
        {
            var value = 6;
            Subject subject = Subject.Bulgarian;
            var mark = new Mark(subject, value);
            Assert.AreEqual(mark.Value, value);
            Assert.AreEqual(mark.Subject, subject);
        }
    }
}
