namespace Computers.Logic.ComputerTypes
{
    using Components.Contracts;

    public abstract class Computer
    {
        public Computer(IMotherboard motherBoard, ICPU cpu, IHardDrive hardDrive)
        {
            this.CPU = cpu;
            this.HardDrive = hardDrive;
            this.MotherBoard = motherBoard; 
        }

        protected IMotherboard MotherBoard { get;  set; }

        protected ICPU CPU { get;  set; }

        protected IHardDrive HardDrive { get;  set; }
    }
}
