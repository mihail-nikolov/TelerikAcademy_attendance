using System;
using System.Globalization;
using System.Threading;


namespace quadric_eq
{
    class quadricEq
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Console.WriteLine("px^2 + qx + r = 0");
            Console.Write("p=");
            float p = float.Parse(Console.ReadLine());
            Console.Write("q=");
            float q = float.Parse(Console.ReadLine());
            Console.Write("r=");
            float r = float.Parse(Console.ReadLine());
            if (p == 0)
            {
                if (q == 0)
                { 
                    Console.WriteLine("no solution");               
                }
                else
                {
                    Console.WriteLine("x=" + (-r / q));
                }
            }
            else 
            {
                float D = (q *q - 4 * p * r);
                Console.WriteLine("D = " + D);
                if (D < 0) 
                { 
                    Console.WriteLine("no real solutions");
                }
                else if (D == 0) 
                { 
                    Console.WriteLine("x=" + (-q / (2 * p)));
                }
                else 
                {
                        Console.WriteLine("x1=" +((-q - Math.Sqrt(D)) / (2 * p)));
                        Console.WriteLine("x2=" + ((-q + Math.Sqrt(D)) / (2 * p)));
                                    
                }
            }
        }
    }
}
