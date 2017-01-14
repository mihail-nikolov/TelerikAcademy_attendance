namespace Computers.Logic.Components
{
    using System;
    using Contracts;

    internal abstract class CPU : ICPU
    {
        private const int MinData = 0;
        private const string TooLowNumberErrorMessage = "Number too low.";
        private const string TooHighNumberErrorMessage = "Number too high.";
        private const string SquareAnswerMessage = "Square of {0} is {1}.";

        protected int maxData;
        private int numberOfBits;

        internal CPU(byte numberOfCores, int numberOfBits)
        {
            this.NumberOfCores = numberOfCores;
            this.numberOfBits = numberOfBits;
        }

        public byte NumberOfCores { get; set; }

        public string SquareNumber(int data)
        {
            string textToDraw = string.Empty;
            if (data < MinData)
            {
                textToDraw = TooLowNumberErrorMessage;
            }
            else if (data > this.maxData)
            {
                textToDraw = TooHighNumberErrorMessage;
            }
            else
            {
                int value = data * data;
                textToDraw = string.Format(SquareAnswerMessage, data, value);
            }

            return textToDraw;
        }

        public int GetRandomNumber(int min, int max)
        {
            Random random = new Random();
            int randomNumber = random.Next(min, max);
            return randomNumber;
        }
    }
}
