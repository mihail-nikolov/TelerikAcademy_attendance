using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Problem 5. Maximal increasing sequence

    Write a program that finds the maximal increasing sequence in an array.
*/
namespace _5.max_incr_seq
{
    class MaxIncrSeq
    {
        static void Main()
        {
            int[] nums = { 3, 2, 3, 4, 2, 2, 3, 4, 5 };
            List<int> theSeq = new List<int> { nums[0] };
            List<int> maxSeq = new List<int> { nums[0] };
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i - 1] < nums[i])
                {
                    theSeq.Add(nums[i]);
                }
                else
                {
                    theSeq.Clear();
                    theSeq.Add(nums[i]);
                }
                if (theSeq.Count > maxSeq.Count)
                {
                    int[] tmpArr = (int[])(theSeq.ToArray()).Clone();
                    maxSeq = tmpArr.ToList();
                }
            }
            string strForPrint = string.Join(", ", maxSeq);
            Console.WriteLine(strForPrint);
        }
    }
}
