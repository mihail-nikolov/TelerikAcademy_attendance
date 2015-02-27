using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 9. Forbidden words

    We are given a string containing a list of forbidden words and a text containing some of these words.
    Write a program that replaces the forbidden words with asterisks.

Example text: Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.

Forbidden words: PHP, CLR, Microsoft

The expected result: ********* announced its next generation *** compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in ***.*/
namespace _9.ForbiddenText
{
    class ForbiddenText
    {
        static string generateStr(string str)
        {
            char[] myStrCharArr = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                myStrCharArr[i] = '*';
            }
            string forbWord = new string(myStrCharArr);
            return forbWord;
        }
        static void Main()
        {
            string[] forbWords = { "PHP", "CLR", "Microsoft" };
            string myText = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
            Console.WriteLine(myText);
            for (int i = 0; i < forbWords.Length; i++)
            {
                string forbWord = generateStr(forbWords[i]);
                myText = myText.Replace(forbWords[i], forbWord);
            }
            Console.WriteLine(myText);
        }
    }
}
