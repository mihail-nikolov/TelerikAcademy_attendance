using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
/*Problem 13. Reverse sentence

    Write a program that reverses the words in given sentence.
*/
namespace _13.ReverseSnt
{
    class ReverseSent
    {
        static public string[] PUNCT = { ",", ".", "!?", "!", "...", "?", ";", ":" };
        static void PrintDict(Dictionary<string, List<int>> myDict)
        {
            foreach (var item in myDict.Keys)
            {
                Console.WriteLine(item);
                List<int> theList = myDict[item];
                foreach (var num in theList)
                {
                    Console.WriteLine(num);
                }
            }
        }
        static string isTherePunct(string str)
        {
            string answer = "";
            
            for (int i = 0; i < PUNCT.Length; i++)
            {
                if (str.Contains(PUNCT[i]))
                {
                    answer += PUNCT[i];
                    return answer;
                }
            }
            return answer;
        }
        static string ClearPunct(string str)
        {
            string newStr = "";
            for (int i = 0; i < PUNCT.Length; i++)
            {
                if (str.Contains(PUNCT[i]))
                {
                    str = str.Replace(PUNCT[i], "");
                }
            }
            newStr = str;
            return newStr;
        }
        static void LoopThroughTheStrArr(string[] strArr, Dictionary<string, List<int>> myDictDB)
        {
            for (int i = 0; i < strArr.Length; i++)
            {
                string isContainigPunct = isTherePunct(strArr[i]);
                if (!String.IsNullOrEmpty(isContainigPunct))
                {
                    if (myDictDB.ContainsKey(isContainigPunct))
                    {
                        myDictDB[isContainigPunct].Add(i);
                    }
                    else
                    {
                        myDictDB.Add(isContainigPunct, new List<int> { });
                        myDictDB[isContainigPunct].Add(i);
                    }
                }
                string newStr = ClearPunct(strArr[i]);
                strArr[i] = newStr;
            }
        }
        static void AddBackThePunct(string[] arr, Dictionary<string, List<int>> myDictDB)
        {
            foreach (var item in myDictDB.Keys)
            {
                List<int> theList = myDictDB[item];
                foreach (var num in theList)
                {
                    arr[num] += item;
                }
            }
        }
        static void Main()
        {
            Dictionary<string, List<int>> myDictDB = new Dictionary<string, List<int>>();
            string myStr = "C# is not C++, not PHP and not Delphi!";
            Console.WriteLine(myStr);
            string[] strArr = myStr.Split(' ');
            LoopThroughTheStrArr(strArr, myDictDB);
            Array.Reverse(strArr);
            AddBackThePunct(strArr, myDictDB);
            string reversedSent = string.Join(" ", strArr);
            Console.WriteLine(reversedSent);
        }
    }
}
