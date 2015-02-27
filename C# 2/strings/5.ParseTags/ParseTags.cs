using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 5. Parse tags

    You are given a text. Write a program that changes the text in all regions surrounded by the tags <upcase> and </upcase> to upper-case.
    The tags cannot be nested.

Example: We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.

The expected result: We are living in a YELLOW SUBMARINE. We don't have ANYTHING else.*/
namespace _5.ParseTags
{
    class ParseTags
    {
        static int HowManyTimesContains(string myStr)
        {
            int counter = 0;
            string lookedStr = "<upcase>";
            int lengthToLook = myStr.Length - lookedStr.Length;
            for (int i = 0; i < lengthToLook; i++)
            {
                if (myStr.Length - i >= lookedStr.Length)
                {
                    if (myStr.Substring(i, lookedStr.Length).Equals(lookedStr))
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }
        static string ParseTagsMethod(int count, string myStr)
        {
            string start = "<upcase>";
            string end = "</upcase>";
            for (int i = 0; i < count; i++)
            {
                int indexStart = myStr.IndexOf(start);
                int indexEnd = myStr.IndexOf(end);
                int lengthToReplace = (indexEnd + end.Length) - indexStart;
                string stringToReplace = myStr.Substring(indexStart, lengthToReplace);
                int lenReplWith = indexEnd - (indexStart + start.Length);
                string replaceWith = myStr.Substring(indexStart + start.Length, lenReplWith);
                myStr = myStr.Replace(stringToReplace, replaceWith.ToUpper());
            }
            return myStr;
        }
        static void Main()
        {
            string myString = " We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
            int counter = HowManyTimesContains(myString);
            string newStr = ParseTagsMethod(counter, myString);
            Console.WriteLine(myString);
            Console.WriteLine(newStr);
        }
    }
}
