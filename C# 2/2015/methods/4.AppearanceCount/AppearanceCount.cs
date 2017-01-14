using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 4. Appearance count

    Write a method that counts how many times given number appears in given array.
    Write a test program to check if the method is workings correctly.
*/
namespace _4.AppearanceCount
{
    class AppearanceCount
    {
        static int CountDigitInArr(int num, int[] arr)
        {
            int counter = 0;
            
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == num)
                {
                    counter++;
                }
            }
            Console.WriteLine("{0} appears in the array: {1} times", num, counter);
            return counter;
        }
        static bool CheckCountDigitInArr(int counter, int num, int[] nums)
        {
            List<int> arrToList = new List<int>();
           for (int i = 0; i < nums.Length; i++)
           {
               if (nums[i] == num)
               {
                   arrToList.Add(nums[i]);
               }
           }
           if (counter == arrToList.Count)
           {
               return true;
           }
           return false;
        }
        static void Main()
        {
            int[] nums = { 1, 2, 3, 4, 5, 2, 3, 2, 4, 2, };
            int num = 2;
            int counter = CountDigitInArr(num, nums);
            bool answer = CheckCountDigitInArr(counter, num, nums);
            Console.WriteLine("the arr contains {0} {1} times", num, counter);
            Console.WriteLine("the program works correctly: {0}",answer);
        }
    }
}
