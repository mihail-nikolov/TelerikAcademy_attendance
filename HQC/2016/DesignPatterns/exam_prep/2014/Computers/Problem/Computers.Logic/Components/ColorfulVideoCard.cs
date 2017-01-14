namespace Computers.Logic.Components
{
    using System;
    using Contracts;

    public class ColorfulVideoCard : VideoCard, IVideoCard
    {
        public ColorfulVideoCard() : base()
        {
        }

        public override void Draw(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
