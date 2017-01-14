namespace Computers.Logic.ComputerTypes
{
    using Computers.Logic.Components.Contracts;

    public class PersonalComputer : Computer
    {
        private const int MinRandomNumber = 1;
        private const int MaxRandomNumber = 10;

        public PersonalComputer(IMotherboard motherBoard, ICPU cpu, IHardDrive hardDrive)
            : base(motherBoard, cpu, hardDrive)
        {
        }

        public void Play(int guessNumber)
        {
            var number = CPU.GetRandomNumber(MinRandomNumber, MaxRandomNumber);
            MotherBoard.SaveRamValue(number);
            if (number == guessNumber)
            {
                MotherBoard.DrawOnVideoCard("You win!");
            }
            else
            {
                MotherBoard.DrawOnVideoCard(string.Format("You didn't guess the number {0}.", number));
            }
        }
    }
}
