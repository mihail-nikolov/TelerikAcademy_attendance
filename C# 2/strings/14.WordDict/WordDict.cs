using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
/*Problem 14. Word dictionary

    A dictionary is stored as a sequence of text lines containing words and their explanations.
    Write a program that enters a word and translates it by using the dictionary.
*/
namespace _14.WordDict
{
    class WordDict
    {
        static Dictionary<string, string> GetDictDB(string str)
        {
            string divider = ": ";
            string[] strArr = str.Split('\n');
            Dictionary<string, string> myDictDB = new Dictionary<string, string>(strArr.Length);
            for (int i = 0; i < strArr.Length; i++)
            {
                string[] wordMeaning = Regex.Split(strArr[i], divider);
                myDictDB[wordMeaning[0]] = wordMeaning[1];
            }
            return myDictDB;
        }
        static void PrintMeaning(string word, Dictionary<string, string> myDictDB)
        {
            if (myDictDB.ContainsKey(word))
            {
                Console.WriteLine(myDictDB[word]);
            }
            else
            {
                Console.WriteLine("not FOUND");
            }
        }
        static void Main()
        {
            string myDictStr = ".NET: platform for applications from Microsoft\nCLR: managed execution environment for .NET\nnamespace: hierarchical organization of classes";
            Console.WriteLine(myDictStr);
            Dictionary<string, string> myDictDB = GetDictDB(myDictStr);
            string myWord = ".NET";
            Console.Write("{0} --> ", myWord);
            PrintMeaning(myWord, myDictDB);
            string myWord1 = ".asdasd";
            Console.Write("{0} --> ", myWord1);
            PrintMeaning(myWord1, myDictDB);
        }
    }
}
