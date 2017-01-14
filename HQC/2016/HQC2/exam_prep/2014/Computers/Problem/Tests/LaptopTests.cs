namespace Tests
{
    using Computers.Logic.Components;
    using Computers.Logic.Components.Contracts;
    using Computers.Logic.ComputerTypes;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class LaptopTests
    {
        [TestMethod]
        public void Charge_ShouldIncreaseWithGivenNumber()
        {
            var motherBoard = new Mock<IMotherboard>();
            var cpu = new Mock<ICPU>();
            var hardDrive = new Mock<IHardDrive>();
            var battery = new LaptopBattery();
            var laptop = new Laptop(motherBoard.Object, cpu.Object, hardDrive.Object, battery);

            motherBoard.VerifyAll();
            cpu.VerifyAll();
            hardDrive.VerifyAll();

            // initial battery - 50%
            laptop.ChargeBattery(10);
            Assert.AreEqual(battery.Percentage, 60);
        }

        [TestMethod]
        public void Charge_ShouldDecreaseWithGivenNumber()
        {
            var motherBoard = new Mock<IMotherboard>();
            var cpu = new Mock<ICPU>();
            var hardDrive = new Mock<IHardDrive>();
            var battery = new LaptopBattery();
            var laptop = new Laptop(motherBoard.Object, cpu.Object, hardDrive.Object, battery);

            motherBoard.VerifyAll();
            cpu.VerifyAll();
            hardDrive.VerifyAll();

            // initial battery - 50%
            laptop.ChargeBattery(-10);
            Assert.AreEqual(battery.Percentage, 40);
        }

        [TestMethod]
        public void Charge_ShouldNotBeIncreasedToMoreThan100()
        {
            var motherBoard = new Mock<IMotherboard>();
            var cpu = new Mock<ICPU>();
            var hardDrive = new Mock<IHardDrive>();
            var battery = new LaptopBattery();
            var laptop = new Laptop(motherBoard.Object, cpu.Object, hardDrive.Object, battery);

            motherBoard.VerifyAll();
            cpu.VerifyAll();
            hardDrive.VerifyAll();

            // initial battery - 50%
            laptop.ChargeBattery(200);
            Assert.AreEqual(battery.Percentage, 100);
        }

        [TestMethod]
        public void Charge_ShouldNotBeDecreasedToLessThan0()
        {
            var motherBoard = new Mock<IMotherboard>();
            var cpu = new Mock<ICPU>();
            var hardDrive = new Mock<IHardDrive>();
            var battery = new LaptopBattery();
            var laptop = new Laptop(motherBoard.Object, cpu.Object, hardDrive.Object, battery);

            motherBoard.VerifyAll();
            cpu.VerifyAll();
            hardDrive.VerifyAll();

            // initial battery - 50%
            laptop.ChargeBattery(-200);
            Assert.AreEqual(battery.Percentage, 0);
        }
    }
}
