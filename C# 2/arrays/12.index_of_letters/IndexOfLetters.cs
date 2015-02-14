using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 12. Index of letters

    Write a program that creates an array containing all letters from the alphabet (A-Z).
    Read a word from the console and print the index of each of its letters in the array.
*/
namespace _12.index_of_letters
{
    class IndexOfLetters
    {
        static void Main()
        {
            string theWord = "smotanalisa";
            theWord = theWord.ToUpper();
            int alphabetCount = 26;
            int firstLetterIndex = 65;
            char[] allLetter = new char[26];
            for (int i = 0; i < alphabetCount; i++)
            {
                allLetter[i] = (char)(i + firstLetterIndex);
            }
            foreach (char letter in theWord)
            {
                for (int i = 0; i < alphabetCount; i++)
                {
                    if (letter == allLetter[i])
                    {
                        Console.WriteLine("{0} -> {1}", letter, i);
                    }
                }
            }
        }
    }
}
