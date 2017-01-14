namespace Computers.Logic.ComputerTypes
{
    using Computers.Logic.Components;
    using Computers.Logic.Components.Contracts;

    public class Laptop : Computer
    {
        private readonly LaptopBattery battery;

        public Laptop(IMotherboard motherBoard, ICPU cpu, IHardDrive hardDrive, LaptopBattery battery)
            : base(motherBoard, cpu, hardDrive)
        {
            this.battery = battery;
        }

        public void ChargeBattery(int percentage)
        {
            this.battery.Charge(percentage);
            this.MotherBoard.DrawOnVideoCard(string.Format("Battery status: {0}%", this.battery.Percentage));
        }
    }
}