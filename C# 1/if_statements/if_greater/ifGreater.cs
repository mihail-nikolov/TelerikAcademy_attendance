using System;


namespace if_greater
{
    class ifGreater
    {
        static void Main()
        {
            Console.Write("a = ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b = ");
            double b = double.Parse(Console.ReadLine());
            if (a > b)
            {
                double tmp = a;
                a = b;
                b = tmp;
            }
            Console.WriteLine("a = {0} \nb = {1}", a, b);

        }
    }
}
