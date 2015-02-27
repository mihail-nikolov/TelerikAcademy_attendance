using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 6. binary to hexadecimal

    Write a program to convert binary numbers to hexadecimal numbers (directly).
*/
namespace _6.BinaryToHexadecimal
{
    class BinaryToHexadecimal
    {
        public static Dictionary<int, string> hexaDecLetter = new Dictionary<int, string>()
            {
                {10, "A"}, {11,"B"}, {12, "C"}, {13, "D"}, {14, "E"}, {15, "F"}
            };
        static string BinToDec(string num)
        {
            int sumOfMyNym = 0;
            for (int i = 0; i < num.Length; i++)
            {
                sumOfMyNym += (int)Char.GetNumericValue(num[i]) * Convert.ToInt32(Math.Pow(2, (num.Length - 1 - i)));
            }
            string result;
            if (sumOfMyNym >= 10)
            {
                result = hexaDecLetter[sumOfMyNym];
            }
            else
            {
                result = sumOfMyNym.ToString();
            }
            return result;
        }
        static string BinToHex(string num)
        {
            string theNum = "";
            for (int i = 0; i < num.Length - 3; i += 4)
            {
                string numStr = num.Substring(i, 4);
                theNum += BinToDec(numStr);
                numStr = "";
            }
            return theNum;
        }
        static void Main()
        {
            string binNum = "0100101000000001";
            string numStr = binNum.Substring(4, 8);
            string strForPrint = BinToHex(binNum);
            Console.WriteLine("{0} --> {1}", binNum, strForPrint);
        }
    }
}
