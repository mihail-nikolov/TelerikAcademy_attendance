using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 1. Decimal to binary

    Write a program to convert decimal numbers to their binary representation.
*/
namespace _1.DecimalToBinary
{
    class DecimalToBinary
    {
        static string Reverse(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        static void Main()
        {
            int n = 43691;
            string binStr = "";
            while (n > 0)
            {
                binStr += (n % 2).ToString();
                n /= 2;
            }
            string newStrNum = Reverse(binStr);
            Console.WriteLine(newStrNum);
        }
    }
}
