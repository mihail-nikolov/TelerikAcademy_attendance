using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
/*Problem 22. Words count

    Write a program that reads a string from the console and lists all different words in the string along with information how many times each word is found.
*/
namespace _22.WordsCount
{
    class WordsCount
    {
        static string[] GetArrFromWords(string str)
        {
            str = Regex.Replace(str, @"[^\w\s]", "");
            string[] arr = str.Split(' ');
            return arr;
        }
        static void PrintDict(Dictionary<string, int> myDict)
        {
            foreach (var entry in myDict)
            {
                Console.WriteLine("{0} --> {1}", entry.Key, entry.Value);
            }
        }
        static void Main()
        {
            string mySent = "blq mlq mlq, blq!";
            mySent = Regex.Replace(mySent, @"[^\w\s]", "");
            mySent = mySent.ToLower();
            string[] words = GetArrFromWords(mySent);
            Dictionary<string, int> wordsDict = new Dictionary<string, int> { };
            string firstWord = words[0];
            wordsDict[firstWord] = 1;
            for (int i = 1; i < words.Length; i++)
            {
                if (wordsDict.ContainsKey(words[i]))
                {
                    wordsDict[words[i]] += 1;
                }
                else
                {
                    wordsDict[words[i]] = 1;
                }
            }
            PrintDict(wordsDict);
        }
    }
}
