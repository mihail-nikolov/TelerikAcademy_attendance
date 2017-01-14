using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 6. String length

    Write a program that reads from the console a string of maximum 20 characters. If the length of the string is less than 20, the rest of the characters should be filled with *.
    Print the result string into the console.
*/
namespace _6.StringLen
{
    class StringLen
    {
        static void Main()
        {
            Console.Write("enter a text with max 20 chars: ");
            string theStr = Console.ReadLine();
            if (theStr.Length > 20)
            {
                Console.WriteLine("the str.Length < 20");
                return;
            }
            theStr = theStr.PadRight(20,'*');
            Console.WriteLine(theStr);
        }
    }
}
