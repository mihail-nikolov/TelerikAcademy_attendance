using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calc_shit
{
    class calc
    {
        static int Factorial(int n)
        {
            int nFactRes = 1;
            for (int i = n; i >= 1; i--)
            {
                nFactRes *= i;
            }
            return nFactRes;
        }
        static void Main(string[] args)
        {
            int n = 3;
            int x = 2;
            double theSum = 1;
            for (int i = 1; i <= n; i++)
            {
                int factRes = calc.Factorial(i);
                theSum += factRes / Math.Pow(x, i);
            }
            Console.WriteLine("the sum is {0:F5}", theSum);
        }
    }
}
