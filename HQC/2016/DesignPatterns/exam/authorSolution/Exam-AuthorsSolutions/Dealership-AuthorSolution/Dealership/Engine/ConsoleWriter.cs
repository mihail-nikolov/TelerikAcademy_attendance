using Dealership.Contracts;
using System;

namespace Dealership.Engine
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string toWrite)
        {
            Console.Write(toWrite);
        }

        public void WriteLine(string toWrite)
        {
            Console.WriteLine(toWrite);
        }
    }
}
