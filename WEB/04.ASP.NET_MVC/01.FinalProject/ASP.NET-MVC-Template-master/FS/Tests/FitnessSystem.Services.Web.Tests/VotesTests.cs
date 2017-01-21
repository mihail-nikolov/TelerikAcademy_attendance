namespace FitnessSystem.Services.Web.Tests
{
    using Data;
    using FitnessSystem.Data.Models;
    using NUnit.Framework;

    [TestFixture]

    public class VotesTests
    {
        [Test]
        public void PointsToAddOnePoint()
        {
            var votes = new VotesServices();

            var vote = new Vote()
            {
                Points = 0
            };
            int asnwer = votes.PointsToAdd(vote, 1);

            Assert.AreEqual(1, asnwer);
        }

        [Test]
        public void PointsToAddZero()
        {
            var votes = new VotesServices();

            var vote = new Vote()
            {
                Points = 0
            };
            int asnwer = votes.PointsToAdd(vote, 0);

            Assert.AreEqual(0, asnwer);
        }

        [Test]
        public void PointsToAddZeroWithExistingMinusOneAndGivenOne()
        {
            var votes = new VotesServices();

            var vote = new Vote()
            {
                Points = -1
            };
            int asnwer = votes.PointsToAdd(vote, 1);

            Assert.AreEqual(0, asnwer);
        }

        [Test]
        public void PointsToAddZeroWithGivenMinusOneAndExistingOne()
        {
            var votes = new VotesServices();

            var vote = new Vote()
            {
                Points = 1
            };
            int asnwer = votes.PointsToAdd(vote, -1);

            Assert.AreEqual(0, asnwer);
        }

        [Test]
        public void PointsToAddMinusOne()
        {
            var votes = new VotesServices();

            var vote = new Vote()
            {
                Points = 0
            };
            int asnwer = votes.PointsToAdd(vote, -1);

            Assert.AreEqual(-1, asnwer);
        }

        [Test]
        public void PointsToAddMinusOne_case1()
        {
            var votes = new VotesServices();

            var vote = new Vote()
            {
                Points = -1
            };
            int asnwer = votes.PointsToAdd(vote, -1);

            Assert.AreEqual(-1, asnwer);
        }

        [Test]
        public void PointsToAddOne_case1()
        {
            var votes = new VotesServices();

            var vote = new Vote()
            {
                Points = 1
            };
            int asnwer = votes.PointsToAdd(vote, 1);

            Assert.AreEqual(1, asnwer);
        }
    }
}
