using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 2. Get largest number

    Write a method GetMax() with two parameters that returns the larger of two integers.
    Write a program that reads 3 integers from the console and prints the largest of them using the method GetMax().
*/
namespace _2.GetLargestNums
{
    class GetLargestNums
    {
        static int getMax(int a, int b)
        {
            if (a > b)
            {
                return a;
            }
            return b;
        }
        static void Main()
        {
            int[] nums = new int[3];
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("enter num: ");
                nums[i] = int.Parse(Console.ReadLine());
            }
            int num1 = getMax(nums[0], nums[1]);
            int num2 = getMax(nums[2], num1);
            Console.WriteLine("the biggest nunm is: {0}", num2);
        }
    }
}
