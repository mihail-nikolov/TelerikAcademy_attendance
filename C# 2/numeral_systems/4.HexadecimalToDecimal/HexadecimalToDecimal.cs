using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 4. Hexadecimal to decimal

    Write a program to convert hexadecimal numbers to their decimal representation.
*/
namespace _4.HexadecimalToDecimal
{
    class HexadecimalToDecimal
    {
        static void Main()
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
