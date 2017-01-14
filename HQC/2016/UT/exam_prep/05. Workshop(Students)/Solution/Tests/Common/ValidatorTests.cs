namespace Tests.Common
{
    using System;

    using Cosmetics.Common;
    using NUnit.Framework;

    [TestFixture]
    public class ValidatorTests
    {
        [TestCase]
        public void CheckIfNull_ShouldThrowNullReferenceException_WhenEmptyObj()
        {
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfNull(null, "text"));
        }

        [TestCase]
        public void CheckIfStringIsNullOrEmpty_ShouldThrowNullReferenceException_WhenNullStr()
        {
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfStringIsNullOrEmpty(null, "text"));
        }

        [TestCase]
        public void CheckIfStringIsNullOrEmpty_ShouldThrowNullReferenceException_WhenEmptyStr()
        {
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfStringIsNullOrEmpty("", "text"));
        }

        [TestCase]
        public void CheckIfStringLengthIsValid_ShouldThrowIndexOutOfRangeException_WhenTextLenOutOfInterval()
        {
            Assert.Throws<IndexOutOfRangeException>(() => Validator.CheckIfStringLengthIsValid("text",5, 10));
        }
    }
}
