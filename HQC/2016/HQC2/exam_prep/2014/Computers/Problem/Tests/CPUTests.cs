namespace Tests
{
    using System.Linq;
    using Computers.Logic.Components;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CPUTests
    {
        [TestMethod]
        public void GetRandomNumber_ShouldAlwayReturnRandomNumberInTheGivenRange()
        {
            var cpu = new CPU64(8);
            int min = 1;
            int max = 10;
            for (int i = 0; i < 30; i++)
            {
                var number = cpu.GetRandomNumber(min, max);
                Assert.IsTrue(Enumerable.Range(min, max).Contains(number));
            }
        }

// =============================================================================================
        [TestMethod]
        public void SquareNumber_ShouldReturnTooLow_WhenNumberLowerThanData()
        {
            var cpu = new CPU64(8);
            string message = cpu.SquareNumber(-1);
            Assert.AreEqual(message, "Number too low.");
        }

        [TestMethod]
        public void SquareNumber_ShouldReturnTooLow_WhenNumberHigherThanMaxData()
        {
            var cpu = new CPU64(8);
            string message = cpu.SquareNumber(1001);
            Assert.AreEqual(message, "Number too high.");
        }

        [TestMethod]
        public void SquareNumber_ShouldSquare_WhenNumberInRange()
        {
            var cpu = new CPU64(8);
            string message = cpu.SquareNumber(500);
            Assert.AreEqual(message, "Square of 500 is 250000.");
        }
    }
}
