using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Problem 15. Hexadecimal to Decimal Number

    Using loops write a program that converts a hexadecimal integer number to its decimal form.
    The input is entered as string. The output should be a variable of type long.
    Do not use the built-in .NET functionality.
*/

namespace hexadecimal_decimal
{
    class HexadecimalDecimal
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> hexaDecLetter = new Dictionary<char, int>()
            {
                {'A', 10}, {'B', 11}, {'C', 12}, {'D', 13}, {'E', 14}, {'F', 15}
            };
            Console.Write("enter hexadecimal: ");
            string hexaInput = Console.ReadLine();
            long decNumber = 0;
            long pow = 1;
            for (int i = hexaInput.Length - 1; i >= 0; i--)
            {
                int num;

                if (hexaInput[i] >= 'A' || hexaInput[i] <= 'F')
                {
                    num = (int)hexaDecLetter[hexaInput[i]];
                }
                else
                {
                    num = (int)hexaInput[i] - 48;
                }
                decNumber += num * pow;
                pow *= 16;
            }
            Console.WriteLine(decNumber);
        }
    }
}
