using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
/*Problem 10. N Factorial

    Write a program to calculate n! for each n in the range [1..100].

Hint: Implement first a method that multiplies a number represented as array of digits by given integer number.*/
namespace _10.NFactorial
{
    class NFactorial
    {
        static BigInteger Factorial(bool isCorrectInput, int n)
        {
            BigInteger answer = 1;
            if (isCorrectInput == true)
            {
                for (int i = n; i >= 1; i--)
                {
                    answer *= i;
                }
            }
            else
            {
                answer = 0;
            }
            return answer; 
        }
        static bool IsCorrectDigit(int n)
        {
            if (n >= 1 && n <= 100)
            {
                return true;
            }
            return false;
        }
        static void Main()
        {
            Console.Write("enter n = ");
            int n = int.Parse(Console.ReadLine());
            bool isCorrect = IsCorrectDigit(n);
            BigInteger answer = Factorial(isCorrect, n);
            if (answer == 0)
            {
                Console.WriteLine("incorrect input");
            }
            else
            {
                Console.WriteLine("{0}! = {1}", n, answer);
            }
        }
    }
}
