namespace Computers.Logic.Components
{
    public class LaptopBattery
    {
        private const int InitialBatteryPower = 50;
        private const int MinBatteryPower = 0;
        private const int MaxBatteryPower = 100;

        public LaptopBattery()
        {
            this.Percentage = InitialBatteryPower;
        }

        public int Percentage { get; private set; }

        public void Charge(int powerPercentage)
        {
            this.Percentage += powerPercentage;

            if (this.Percentage > MaxBatteryPower)
            {
                this.Percentage = MaxBatteryPower;
            }

            if (this.Percentage < MinBatteryPower)
            {
                this.Percentage = MinBatteryPower;
            }
        }
    }
}
