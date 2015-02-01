using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Problem 13. Binary to Decimal Number

    Using loops write a program that converts a binary integer number to its decimal form.
    The input is entered as string. The output should be a variable of type long.
    Do not use the built-in .NET functionality.
*/

namespace bin_to_dec
{
    class BinDec
    {
        static void Main(string[] args)
        {
            string myBin = "1010101010101011";
            double sumOfMyNym = 0;
            for (int i = 0; i <= myBin.Length - 1; i++)
            {
                sumOfMyNym += (int)Char.GetNumericValue(myBin[i]) * Math.Pow(2, (myBin.Length - 1 - i));
                //int val = (int)Char.GetNumericValue('8');
            }
            Console.WriteLine(sumOfMyNym);
        }
    }
}
