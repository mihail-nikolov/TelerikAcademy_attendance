using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 9. Frequent number

    Write a program that finds the most frequent number in an array.
*/
namespace _9.frequent_number
{
    class FrequentNumber
    {
        static void Main()
        {
            int counter = 1;
            int maxCounter = 1;
            int[] nums = { 2, 2, 3, 4, 5, 6, 2};
            int theNum = nums[0];
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] == nums[i])
                    {
                        counter++;
                    }
                }
                if (counter > maxCounter)
                {
                    theNum = nums[i];
                    maxCounter = counter;
                }
                counter = 1;
            }
            if (maxCounter > 1)
            {
                Console.WriteLine("you have {0} ({1}) times", theNum, maxCounter);
            }
            else if (maxCounter == 1)
            {
                Console.WriteLine("you have every number once");
            }
        }
    }
}
