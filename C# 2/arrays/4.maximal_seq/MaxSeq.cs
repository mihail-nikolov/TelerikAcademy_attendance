using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Problem 4. Maximal sequence

    Write a program that finds the maximal sequence of equal elements in an array.
*/
namespace _4.maximal_seq
{
    class MaxSeq
    {
        static void Main()
        {
            int theNum;
            int counter = 1;
            int maxCounter = 1;
            int[] nums = { 2, 1, 1, 2, 3, 3, 2, 2, 2, 2};
            theNum = nums[0];
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i+1] == nums[i])
                {
                    counter++;
                }
                else
                {  
                    counter = 1;
                }
                if (maxCounter < counter)
                {
                    maxCounter = counter;
                    theNum = nums[i];
                }
            }
            for (int i = 0; i < maxCounter; i++)
            {
                Console.Write("{0} ", theNum);
            }
        }
    }
}
