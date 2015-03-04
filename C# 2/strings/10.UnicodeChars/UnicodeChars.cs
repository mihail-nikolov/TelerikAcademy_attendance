using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 10. Unicode characters

    Write a program that converts a string to a sequence of C# Unicode character literals.
    Use format strings.
*/
namespace _10.UnicodeChars
{
    class UnicodeChars
    {
        static string GetUnicodeString(string str)
        {
            StringBuilder uni = new StringBuilder();
            foreach (char c in str)
            {
                uni.Append("\\u");
                uni.Append(String.Format("{0:x4}", (int)c));
            }
            return uni.ToString();
        }
        static void Main()
        {
            string str = "dgsdgs";
            string strUni = GetUnicodeString(str);
            Console.WriteLine(strUni);
        }
    }
}
