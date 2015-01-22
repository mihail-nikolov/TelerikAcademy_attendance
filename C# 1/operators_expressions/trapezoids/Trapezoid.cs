using System;


namespace trapezoids
{
    class Trapezoid
    {
        static void Main()
        {
            double a = 7;
            double b = 5;
            double h = 12;
            double area = ((a + b) / 2) * h;
            Console.WriteLine("a = {0}", a);
            Console.WriteLine("b = {0}", b);
            Console.WriteLine("h = {0}", h);
            Console.WriteLine("area = {0}", area);
        }
    }
}
