using Dealership.Contracts;
using System;

namespace Dealership.Engine
{
    public class ConsoleReader : IReader
    {
        public string Readline()
        {
            return Console.ReadLine();
        }
    }
}
