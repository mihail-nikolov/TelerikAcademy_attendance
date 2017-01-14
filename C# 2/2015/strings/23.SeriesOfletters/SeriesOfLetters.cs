using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 23. Series of letters

    Write a program that reads a string from the console and replaces all series of consecutive identical letters with a single one.
*/
namespace _23.SeriesOfletters
{
    class SeriesOfLetters
    {
        static void Main()
        {
            string str = "aaaaabbbbbcdddeeeedssaa";
            string newStr = str[0].ToString();
            for (int i = 1; i < str.Length; i++)
            {

                if (str[i] != str[i - 1])
                {
                    newStr += str[i];
                }
            }
            Console.WriteLine(str);
            Console.WriteLine(newStr);
        }
    }
}

