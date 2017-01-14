namespace SchoolSystem.ConsoleApplication
{
    using System;
    using Core.Contracts;

    public class ConsoleReaderProvider : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
