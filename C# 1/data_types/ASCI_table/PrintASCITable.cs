using System;


namespace ASCI_table
{
    class PrintASCITable
    {
        static void Main()
        {
            for (int number = 0; number <= 255; number++)
            {
                char character = (char)number;
                Console.WriteLine("{0} --> {1}", number, character);
            }
        }
    }
}
