namespace Computers.Logic.Components
{
    using Computers.Logic.Components.Contracts;

    internal class CPU64 : CPU, ICPU
    {
        private const int MaxData = 1000;
        private const int NumberOfBits = 64;

        public CPU64(byte numberOfCores) 
            : base(numberOfCores, NumberOfBits)
        {
            this.maxData = MaxData;
        }
    }
}
