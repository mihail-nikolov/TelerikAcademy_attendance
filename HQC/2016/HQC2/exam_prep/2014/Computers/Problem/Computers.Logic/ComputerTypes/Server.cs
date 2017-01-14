namespace Computers.Logic.ComputerTypes
{
    using Computers.Logic.Components.Contracts;

    public class Server : Computer
    {
        public Server(IMotherboard motherBoard, ICPU cpu, IHardDrive hardDrive)
            : base(motherBoard, cpu, hardDrive)
        {
        }

        public void Process(int value)
        {
            string answer = this.CPU.SquareNumber(value);
            this.MotherBoard.DrawOnVideoCard(answer);
        }
    }
}
