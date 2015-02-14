using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Problem 8. Maximal sum

    Write a program that finds the sequence of maximal sum in given array.
*/
namespace _8.max_sum
{
    class MaximalSum
    {
        static void Main()
        {
            int[] arr = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };
            int maxSum = arr[0];
            int maxLength = 1;
            int maxIndex = 0;
            int sum = arr[0];
            int index = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                sum += arr[i];
                if (arr[i] > sum)
                {
                    sum = arr[i];
                    index = i;
                }
                if (sum > maxSum)
                {
                    maxSum = sum;
                    maxIndex = index;
                    maxLength = i - index + 1;
                }
            }
            string strForPrinit = "";
            for (int i = 0; i < maxLength; i++)
            {
                strForPrinit += arr[maxIndex + i] + " ";
            }
            Console.WriteLine(strForPrinit);
        }

    }
}