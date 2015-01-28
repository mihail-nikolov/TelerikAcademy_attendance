using System;
using System.Globalization;
using System.Threading;


namespace formatting_numbers
{
    class formatNum
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Console.WriteLine("three real nums: ");
            Console.Write("a=");
            int a = int.Parse(Console.ReadLine());
            if (a < 0 || a > 500)
            {
                Console.WriteLine("a must be in interval [0; 500]");
                return;
            }
            Console.Write("b=");
            float b = float.Parse(Console.ReadLine());
            Console.Write("c=");
            float c = float.Parse(Console.ReadLine());
            Console.WriteLine("{0,-10}|{1,10}|{2:F2,10}|{3:F3,-10}|",
                                          a.ToString("X"), Convert.ToString(a, 2).PadLeft(10, '0'), b, c);
        }
    }
}
