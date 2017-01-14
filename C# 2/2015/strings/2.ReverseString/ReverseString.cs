using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 2. Reverse string

    Write a program that reads a string, reverses it and prints the result at the console.
*/
namespace _2.ReverseString
{
    class ReverseString
    {
        public static string RevStr(string str)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = str.Length - 1; i >= 0; i--)
            {
                sb.Append(str[i]);
            }
            return sb.ToString();
        }
        static void Main()
        {
            string myStr = "I am Misho";
            string reversed = RevStr(myStr);
            Console.WriteLine("{0} --> {1}", myStr, reversed);
        }
    }
}
