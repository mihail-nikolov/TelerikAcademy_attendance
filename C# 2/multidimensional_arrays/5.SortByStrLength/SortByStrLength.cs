using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 5. Sort by string length

    You are given an array of strings. Write a method that sorts the array by the length of its elements (the number of characters composing them).
*/
namespace _5.SortByStrLength
{
    class SortByStrLength
    {
        static void swap(string[] arr, int i, int j)
        {
            string tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }
        static void Main()
        {
            string[] arr = { "are", "given", "an", "strings", "characters", "method", "its" };
            string unsortedArr = string.Join(", ", arr);
            Console.WriteLine(unsortedArr);
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[i].Length > arr[j].Length)
                    {
                        swap(arr, i, j);
                    }
                }
            }
            string sortedArr = string.Join(", ", arr);
            Console.WriteLine(sortedArr);
        }
    }
}
