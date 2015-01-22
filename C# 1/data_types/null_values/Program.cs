using System;


namespace null_values
{
    class Program
    {
        static void Main()
        {
            int? a = null;
            double? b = null;
            Console.WriteLine("BEFORE\na: {0}\nb: {1}", a, b);
            a = 5;
            b = 6;
            Console.WriteLine("AFTER\na: {0}\nb: {1}", a, b);
        }
    }
}
