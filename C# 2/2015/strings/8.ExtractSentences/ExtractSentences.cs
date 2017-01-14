using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
/*Problem 8. Extract sentences

    Write a program that extracts from a given text all sentences containing given word.

Example:

The word is: in

The text is: We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.

The expected result is: We are living in a yellow submarine. We will move out of it in 5 days.

Consider that the sentences are separated by . and the words – by non-letter symbols.*/
namespace _8.ExtractSentences
{
    class ExtractSentences
    {
        static bool IfArrContains(string[] arr, string word)
        {
            foreach (string item in arr)
            {
                if (item.ToLower() == word.ToLower())
                {
                    return true;
                }
            }
            return false;
        }
        static string[] GetArrFromWords(string str)
        {
            str = Regex.Replace(str, @"[^\w\s]", "");
            string[] arr = str.Split(' ');
            return arr;
        }
        static string[] ParseToArr(string str)
        {
            string[] arr = str.Split('.');
            return arr;
        }
        static string[] ContainingTheWord(string word, string[] sentences)
        {
            int indexCounter = 0;
            string[] newStrArr = new string[sentences.Length];
            for (int i = 0; i < sentences.Length; i++)
            {
                string[] wordsArr = GetArrFromWords(sentences[i]);
                if (IfArrContains(wordsArr, word))
                {
                    newStrArr[indexCounter] = sentences[i];
                    indexCounter++;
                }
            }
            return newStrArr;
        }
        static void PrintTheSent(string[] myStr)
        {
            for (int i = 0; i < myStr.Length; i++)
            {
                Console.WriteLine(myStr[i]);
            }
        }
        static void Main(string[] args)
        {
            string word = "in";
            string myStr = " We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
            Console.WriteLine(myStr);
            string[] arr = ParseToArr(myStr);
            string[] containingTheWordArr = ContainingTheWord(word, arr);
            PrintTheSent(containingTheWordArr);

        }

    }
}
