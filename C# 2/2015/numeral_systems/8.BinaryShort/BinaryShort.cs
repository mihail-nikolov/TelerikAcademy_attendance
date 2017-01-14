using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 8. Binary short

    Write a program that shows the binary representation of given 16-bit signed integer number (the C# type short).
*/
namespace _8.BinaryShort
{
    class BinaryShort
    {
        public static string ShortToBinary(short number)
        {
            string result = "";
            short[] resultArray = new short[16];
            short mask;
            if (number == 0)
            {
                result = "0";
            }
            else if (number > 0)
            {
                for (short i = 0; i < resultArray.Length; i++)
                {
                    mask = (short)(1 << (resultArray.Length - i - 1));
                    resultArray[i] = (short)((mask & number) >> (resultArray.Length - i - 1));
                }
                int counter = 0;
                while (resultArray[counter] == 0)
                {
                    counter++;
                }
                for (int i = counter; i < resultArray.Length; i++)
                {
                    result += Convert.ToString(resultArray[i]);
                }
            }
            else
            {
                for (short i = 0; i < resultArray.Length; i++)
                {
                    mask = (short)(1 << (resultArray.Length - i - 1));
                    resultArray[i] = (short)(1 - ((mask & ~number) >> (resultArray.Length - i - 1)));
                    result += Convert.ToString(resultArray[i]);
                }
            }
            return result;
        }
        static void Main()
        {
            Console.WriteLine("n= ");
            short valN = short.Parse(Console.ReadLine());
            Console.WriteLine("The binary representation of {0} is: {1}", valN, ShortToBinary(valN));
        } 
    }
}
