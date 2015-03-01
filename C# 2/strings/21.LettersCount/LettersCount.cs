using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
/*Problem 21. Letters count

    Write a program that reads a string from the console and prints all different letters in the string along with information how many times each letter is found.
*/
namespace _21.LettersCount
{
    class LettersCount
    {
        static void PrintDict(Dictionary<char, int> myDict)
        {
            foreach (var entry in myDict)
            {
                Console.WriteLine("{0} --> {1}", entry.Key, entry.Value); 
            }
        }
        static void Main()
        {
            string mySent = "blq  ,. ~!blq";
            mySent = Regex.Replace(mySent, @"[^\w]", "");
            mySent = mySent.ToLower();
            Dictionary<char, int> letters = new Dictionary<char, int> { };
            char firstLetter = mySent[0];
            letters[firstLetter] = 1;
            for (int i = 1; i < mySent.Length; i++)
            {
                if (letters.ContainsKey(mySent[i]))
                {
                    letters[mySent[i]] += 1;
                }
                else
                {
                    letters[mySent[i]] = 1;
                }
            }
            PrintDict(letters);
        }
    }
}
