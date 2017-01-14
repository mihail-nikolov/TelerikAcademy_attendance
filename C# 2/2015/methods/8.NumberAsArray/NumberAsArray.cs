using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 8. Number as array

    Write a method that adds two positive integer numbers represented as arrays of digits (each array element arr[i] contains a digit; the last digit is kept in arr[0]).
    Each of the numbers that will be added could have up to 10 000 digits.
*/
namespace _8.NumberAsArray
{
    class NumberAsArray
    {
        static bool CheckCorrectInput(string n1, string n2)
        {
            if ((n1.Length <= 10000 && n1.Length > 0) || (n2.Length <= 10000 && n2.Length > 0))
            {
                return true;
            }
            return false;
        }
        static string[] MakeNumsToArrs(uint n1, uint n2)
        {
            string[] answer = new string[2];
            string nOneStr = n1.ToString();
            string nTwoStr = n2.ToString();
            if (CheckCorrectInput(nOneStr,nTwoStr))
            {
                char[] charArray1 = nOneStr.ToCharArray();
                char[] charArray2 = nTwoStr.ToCharArray();
                Array.Reverse(charArray1);
                string n1Reversed = new string(charArray1);
                Array.Reverse(charArray2);
                string n2Reversed = new string(charArray2);
                answer[0] = n1Reversed;
                answer[1] = n2Reversed;
                return answer;
            }
            answer[0] = "-1";
            return answer;
        }
        static void Main()
        {
            uint n1 = 1024;
            uint n2 = 923;
            string[] answer = MakeNumsToArrs(n1, n2);
            if (answer[0] == "-1")
            {
                Console.WriteLine("incorrect input");
                return;
            }
            Console.WriteLine("{0} -- > {1}", n1, answer[0]);
            Console.WriteLine("{0} -- > {1}", n2, answer[1]);
        }
    }
}
