namespace Computers.Logic.Components
{
    using Computers.Logic.Components.Contracts;

    internal class CPU32 : CPU, ICPU
    {
        private const int MaxData = 500;
        private const int NumberOfBits = 32;

        public CPU32(byte numberOfCores) 
            : base(numberOfCores, NumberOfBits)
        {
            this.maxData = MaxData;
        }
    }
}
