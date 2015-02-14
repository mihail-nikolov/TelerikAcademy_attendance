using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 15. Prime numbers

    Write a program that finds all prime numbers in the range [1...10 000 000]. Use the Sieve of Eratosthenes algorithm.
*/
namespace _15.prime_numbers
{
    class PrimeNums
    {
        static void Main()
        {
            long n = 23;
            bool[] nums = new bool[n];
            for (int i = 2; i < n; i++)
            {
                nums[i] = true;
            }
            for (int i = 2; i < n; i++)
            {
                if (nums[i])
                {
                    for (long j = 2; (j * i) < n; j++)
                    {
                        nums[j * i] = false;
                    }
                }
            } 
            Console.WriteLine("the prime nubers are: ");
            for (int i = 2; i < nums.Length; i++)
            {
                if (nums[i])
                {
                    Console.Write("{0} ", i);
                }
            }

        }
    }
}
