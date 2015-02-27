using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
/*Problem 20. Palindromes

    Write a program that extracts from a given text all palindromes, e.g. ABBA, lamal, exe.
*/
namespace _20.Palindromes
{
    class Palindromes
    {
        static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        static bool IsPalindrom(string word)
        {
            word = word.ToLower();
            string palWord = Reverse(word);
            if (palWord == word)
            {
                return true;
            }
            return false;
        }
        static void PrintPalindromes(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (IsPalindrom(arr[i]))
                {
                    Console.WriteLine(arr[i]);
                }
            }
        }   
        static string[] GetArrFromWords(string str)
        {
            str = Regex.Replace(str, @"[^\w\s]", "");
            string[] arr = str.Split(' ');
            return arr;
        }
        static void Main()
        {
            string myText = "ABBA lamal, exe! kh;asd";
            Console.WriteLine(myText);
            string[] words = GetArrFromWords(myText);
            PrintPalindromes(words);
        }
    }
}
