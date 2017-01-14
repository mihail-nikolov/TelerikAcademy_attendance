using ConsoleWebServer.Framework;
using System;


namespace ConsoleWebServer.Application
{
    public class ConsoleWriter : IWriter
    {
        public void Write(object toWrite)
        {
            Console.Write(toWrite);
        }

        public void WriteLine(object toWrite)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(toWrite);
            Console.ResetColor();
        }
    }
}
