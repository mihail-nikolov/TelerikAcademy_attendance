using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 5. Hexadecimal to binary

    Write a program to convert hexadecimal numbers to binary numbers (directly).
*/
namespace _5.HexadecimalToBinary
{
    class HexadecimalToBinary
    {
        public static Dictionary<char, int> hexaDecLetter = new Dictionary<char, int>()
            {
                {'A', 10}, {'B', 11}, {'C', 12}, {'D', 13}, {'E', 14}, {'F', 15}
            };
        static string DecToBin(int n)
        {
            string binary = Convert.ToString(n, 2);
            binary = binary.PadLeft(4, '0');
            return binary;
        }
        static string HexaDecToBin(string numStr)
        {
            string theBinNum = "";
            for (int i = 0; i < numStr.Length; i++)
            {
                int theDigit;
                if (hexaDecLetter.ContainsKey(numStr[i]))
                {
                    theDigit = hexaDecLetter[numStr[i]];
                }
                else
                {
                    theDigit = (int)Char.GetNumericValue(numStr[i]);
                }
                theBinNum += DecToBin(theDigit);
            }
            return theBinNum;
        }
        static void Main()
        {
            string hexaDecNum = "4E";
            string strForPrint = HexaDecToBin(hexaDecNum);
            Console.WriteLine("{0} --> {1}", hexaDecNum, strForPrint);
        }
    }
}
