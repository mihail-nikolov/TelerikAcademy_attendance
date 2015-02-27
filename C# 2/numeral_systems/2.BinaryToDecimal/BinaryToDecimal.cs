using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 2. Binary to decimal

    Write a program to convert binary numbers to their decimal representation.
*/
namespace _2.BinaryToDecimal
{
    class BinaryToDecimal
    {
        static void Main()
        {
            string myBin = "1010101010101011";
            double sumOfMyNym = 0;
            for (int i = 0; i <= myBin.Length - 1; i++)
            {
                sumOfMyNym += (int)Char.GetNumericValue(myBin[i]) * Math.Pow(2, (myBin.Length - 1 - i));
            }
            Console.WriteLine(sumOfMyNym);
        }
    }
}
