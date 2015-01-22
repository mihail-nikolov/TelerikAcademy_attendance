using System;

namespace PrintDateTime
{
    class PrintDateTime
    {
        static void Main(string[] args)
        {
            string time = DateTime.Now.ToString("h:mm:ss tt");
            Console.WriteLine(time);
        }
    }
}
