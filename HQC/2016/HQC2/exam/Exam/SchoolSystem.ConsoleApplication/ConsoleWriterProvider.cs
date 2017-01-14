namespace SchoolSystem.ConsoleApplication
{
    using System;
    using Core.Contracts;

    public class ConsoleWriterProvider : IWriter
    {
        public void WriteLine(string lineToWrite)
        {
            Console.WriteLine(lineToWrite);
        }
    }
}
