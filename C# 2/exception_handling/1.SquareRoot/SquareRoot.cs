using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 1. Square root

    Write a program that reads an integer number and calculates and prints its square root.
        If the number is invalid or negative, print Invalid number.
        In all cases finally print Good bye.
    Use try-catch-finally block.
*/
namespace _1.SquareRoot
{
    class SquareRoot
    {
        static void Main()
        {
            Console.Write("n = ");
            try
            {
                int num = int.Parse(Console.ReadLine());
                if (num <= 0)
                {
                    throw new ArgumentException("Invaild Number");
                }
                Console.WriteLine(Math.Sqrt(num));
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Number");
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }
            finally
            {
                Console.WriteLine("good bye");
            }
            
        }
    }
}
