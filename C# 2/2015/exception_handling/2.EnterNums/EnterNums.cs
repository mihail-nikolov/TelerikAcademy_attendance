using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 2. Enter numbers

    Write a method ReadNumber(int start, int end) that enters an integer number in a given range [start…end].
        If an invalid number or non-number text is entered, the method should throw an exception.
    Using this method write a program that enters 10 numbers: a1, a2, … a10, such that 1 < a1 < … < a10 < 100
*/
namespace _2.EnterNums
{
    class EnterNums
    {
        static int ReadNumber(int start, int end)
        {
            Console.Write("enter n = ");
            int n = int.Parse(Console.ReadLine());
            if (n > end || n < start)
            {
                throw new ArgumentException("num must be in the given interval");
            }
            return n;
        }
        static void Main()
        {
            int start = 1;
            int end = 100;
            for (int i = 1; i < 10; i++)
            {
                try
                {
                    int n = ReadNumber(start, end);
                    start = n;
                }
                catch (FormatException)
                {
                    Console.WriteLine("num must be INTEGER");
                    Console.WriteLine("bye bye");
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("bye bye");
                    break;
                }
            }
            Console.WriteLine("GoodBye");
        }
    }
}
