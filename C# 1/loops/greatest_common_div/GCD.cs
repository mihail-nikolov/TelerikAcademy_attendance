using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*3
 Problem 17.* Calculate GCD

    Write a program that calculates the greatest common divisor (GCD) of given two integers a and b.
    Use the Euclidean algorithm (find it in Internet).
*/
namespace greatest_common_div
{
    class GCD
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = -15;
            int lowerAB = Math.Min(a, b);
            int GCD = 1;
            for (int i = 1; i <= Math.Abs(lowerAB); i++)
            {
                if (a % i == 0 && b % i == 0)
                {
                    if (i > GCD)
                    {
                        GCD = i;
                    }
                }
            }
            Console.WriteLine("GCD is {0}", GCD);
        }
    }
}
