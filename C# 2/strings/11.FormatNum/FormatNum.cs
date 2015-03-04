using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 11. Format number

    Write a program that reads a number and prints it as a decimal number, hexadecimal number, percentage and in scientific notation.
    Format the output aligned right in 15 symbols.
*/
namespace _11.FormatNum
{
    class FormatNum
    {
        static void Main()
        {
            int number = 15;
            string decimalNum = number.ToString("F2");
            string hexNum = number.ToString("X");
            string percNum = number.ToString("P");
            string scienNum = number.ToString("E");
            Console.WriteLine("{0, 15}|{1, 15}|{2, 15}|{3, 15}",
            decimalNum, hexNum, percNum, scienNum);
        }
    }
}
