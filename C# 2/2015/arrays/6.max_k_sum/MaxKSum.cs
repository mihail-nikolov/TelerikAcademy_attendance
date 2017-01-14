using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Problem 6. Maximal K sum

    Write a program that reads two integer numbers N and K and an array of N elements from the console.
    Find in the array those K elements that have maximal sum.
*/
namespace _6.max_k_sum
{
    class MaxKSum
    {
        static void Main()
        {
            Console.Write("N = ");
            int N = int.Parse(Console.ReadLine());
            Console.Write("K = ");
            int K = int.Parse(Console.ReadLine());
            int[] nums = new int[N];
            List<int> newNumsList = new List<int> { };
            for (int i = 0; i < N; i++)
            {
                Console.Write("num = ");
                nums[i] = int.Parse(Console.ReadLine());
            }
            List<int> numsList = nums.ToList();
            int maxNum = numsList[0];
            int theIndex = 0;
            for (int i = 0; i < K; i++)
            {
                for (int j = 1; j < numsList.Count; j++)
                {
                    if (numsList[j] > maxNum)
                    {
                        maxNum = numsList[j];
                        theIndex = j;
                    }
                }
                newNumsList.Add(maxNum);
                numsList.RemoveAt(theIndex);
                theIndex = 0;
                maxNum = numsList[0];
            }
            string strForPrint = string.Join(", ", newNumsList);
            Console.WriteLine(strForPrint);
        }
    }
}
