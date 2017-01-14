namespace Computers.Logic.Components
{
    using Computers.Logic.Components.Contracts;

    internal class CPU128 : CPU, ICPU
    {
        private const int MaxData = 2000;
        private const int NumberOfBits = 128;

        public CPU128(byte numberOfCores)
            : base(numberOfCores, NumberOfBits)
        {
            this.maxData = MaxData;
        }
    }
}
