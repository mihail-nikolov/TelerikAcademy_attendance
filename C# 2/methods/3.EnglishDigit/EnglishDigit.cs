using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 3. English digit

    Write a method that returns the last digit of given integer as an English word.
*/
namespace _3.EnglishDigit
{
    class EnglishDigit
    {
        static string GetEnglishDigit(int num)
        {
            Dictionary<char, string> digitMap = new Dictionary<char, string>()
            {
                {'0', "zero"}, {'1', "one"}, {'2', "two"}, {'3', "three"}, {'4', "four"}, {'5', "five"},
                {'6' , "six"}, {'7', "seven"}, {'8' , "eight"}, {'9', "nine"}
            };
            string numStr = num.ToString();
            char theLastDigit = numStr[numStr.Length - 1];
            string answer = digitMap[theLastDigit];
            return answer;
        }
        static void Main()
        {
            Console.Write("enter n = ");
            int num = int.Parse(Console.ReadLine());
            string answer = GetEnglishDigit(num);
            Console.WriteLine("the last digit is {0}", answer);
        }
    }
}
