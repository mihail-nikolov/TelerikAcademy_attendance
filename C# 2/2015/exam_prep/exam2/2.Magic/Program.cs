using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace _2.Magic
{
    class Program
    {
        static List<string> FillTheArr(int n)
        {
            //var regex = new Regex("^[a-z]+$"); - check for only little English letters
            List<string> words = new List<string> { };
            for (int i = 0; i < n; i++)
            {
                words.Add(Console.ReadLine());
            }
            return words;
        }


        static void Reorder(List<string> myList)
        {
            for (int i = 0; i < myList.Count; i++)
            {
                int index = myList[i].Length % (myList.Count + 1);
                string word = myList[i];
                myList[i] = null;
                myList.Insert(index, word);
                myList.Remove(null);
            }
        }

        static int GetMaxLengthInArr(List<string> arr)
        {
            int maxLen = arr[0].Length;
            for (int i = 1; i < arr.Count; i++)
            {
                if (arr[i].Length > maxLen)
                {
                    maxLen = arr[i].Length;
                }
            }
            return maxLen;
        }


        static void PrintArr(List<string> arr)
        {
            StringBuilder result = new StringBuilder();
            int maxWordLen = GetMaxLengthInArr(arr);
            for (int i = 0; i < maxWordLen; i++)
            {
                for (int j = 0; j < arr.Count; j++)
                {
                    if (arr[j].Length > i)
                    {
                        result.Append(arr[j][i]);
                    }
                }
            }
            Console.WriteLine(result);
        }


        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string>words = FillTheArr(n);
            Reorder(words);
            //Console.WriteLine(reorderedWords[0]);
            PrintArr(words);
            /* try
             {
               
             }
             catch (ArgumentException ae)
             {

                 Console.WriteLine(ae.Message);
             }*/

        }
    }
}
