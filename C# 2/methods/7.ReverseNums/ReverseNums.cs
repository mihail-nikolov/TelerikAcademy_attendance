using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 7. Reverse number

    Write a method that reverses the digits of given decimal number.
*/
namespace _7.ReverseNums
{
    class ReverseNums
    {
        static string Reverse(int num)
        {
            string numStr = num.ToString();
            string reversedNum = "";
            for (int i = numStr.Length - 1; i >= 0; i--)
            {
                reversedNum += numStr[i];
            }
            return reversedNum;
        }
        static void Main()
        {
            int num = 256;
            string reversedNum = Reverse(num);
            Console.WriteLine("num : {0}, reversed: {1}", num, reversedNum);
        }
    }
}
