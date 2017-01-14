namespace Computers.Logic.Components
{
    using System;
    using Contracts;

    public class MonochromeVideoCard : VideoCard, IVideoCard
    {
        public MonochromeVideoCard() : base()
        {
        }

        public override void Draw(string text)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
