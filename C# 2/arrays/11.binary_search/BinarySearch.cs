using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Problem 11. Binary search

    Write a program that finds the index of given element in a sorted array of integers by using the Binary search algorithm.
*/
namespace _11.binary_search
{
    class BinarySearch
    {
        static int binSearch(int n, int[] arr, int min, int max)
        {
            int mid = (min + max) / 2;
            if (min > max)
            {
                return -1;
            }
            else
            {
                if (n == arr[mid])
                {
                    return mid;
                }
                else if (n > arr[mid])
                {
                    min = mid + 1;
                    return BinarySearch.binSearch(n, arr, min, max);
                }
                else
                {
                    max = mid - 1;
                    return BinarySearch.binSearch(n, arr, min, max);
                }
            }
        }
        static void Main()
        {
            int[] arr = { 1, 2, 3, 4, 6, 5, 10, 9 };
            Array.Sort(arr);
            string strForPrint = string.Join(" ", arr);
            Console.WriteLine("sorted array: {0}", strForPrint);
            Console.Write("enter number ");
            int myNum = int.Parse(Console.ReadLine());
            int result = BinarySearch.binSearch(myNum, arr, 0, arr.Length - 1);
            if (result == -1)
            {
                Console.WriteLine("not such a number");
                return;
            }
            Console.WriteLine("the index of number {0} is {1}", myNum, result);

        }
    }
}
