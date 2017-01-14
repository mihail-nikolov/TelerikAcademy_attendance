using ConsoleWebServer.Framework;
using System;

namespace ConsoleWebServer.Application
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
