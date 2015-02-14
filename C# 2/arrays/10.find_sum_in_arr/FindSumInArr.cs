using System;
/*Problem 10. Find sum in array

    Write a program that finds in given array of integers a sequence of given sum S (if present).
*/
class FindSumInArr
{
    static void Main()
    {
        int[] nums = { 4, 3, 1, 4, 2, 5, 8 };
        int searchedSum = 11;
        string strForPrint = "";
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i, sum = 0; j < nums.Length; j++)
            {
                if ((sum += nums[j]) == searchedSum)
                {
                    for (int k = 0; k < j - i + 1; k++)
                    {
                        strForPrint += (nums[i + k]) + " ";
                    }
                }
            }
        }
        if (strForPrint.Length == 0)
        {
            Console.WriteLine("there is no such a sequence");
            return;
        }
        Console.WriteLine(strForPrint);

    }
}