using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Problem 18.* Trailing Zeroes in N!

    Write a program that calculates with how many zeroes the factorial of a given number n has at its end.
    Your program should work well for very big numbers, e.g. n=100000.
*/
namespace trailing_zeroes
{
    class TrailingZeroes
    {
        public static long Factorial(int n)
        {
            long nFactRes = 1;
            for (int i = n; i >= 1; i--)
            {
                nFactRes *= i;
            }
            return nFactRes;
        }
        static void Main()
        {
            char zeroChar = '0';
            int counter = 0;
            int n = 100000;
            long result = TrailingZeroes.Factorial(n);
            string strRes = result.ToString();
            for (int i = strRes.Length - 1; i >= 0; i--)
            {
                if (strRes[i] == zeroChar)
                {
                    counter++;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("the result contains {0} * 0", counter);
        }
    }
}
