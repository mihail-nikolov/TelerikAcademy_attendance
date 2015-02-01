using System;
/*Problem 14. Decimal to Binary Number

    Using loops write a program that converts an integer number to its binary representation.
    The input is entered as long. The output should be a variable of type string.
    Do not use the built-in .NET functionality.
*/

namespace dec_to_bin
{
    class DecBin
    {
        public static string Reverse(string str)
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
            string newStrNum = DecBin.Reverse(binStr);
            Console.WriteLine(newStrNum);
        }
    }
}
