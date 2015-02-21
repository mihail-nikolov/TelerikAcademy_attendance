using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 9. Sorting array

    Write a method that return the maximal element in a portion of array of integers starting at given index.
    Using it write another method that sorts an array in ascending / descending order*/
namespace _9.SortingArr
{
    class SortingArr
    {
        static void Swap(int[]arr,int i,int j)
        {
            int tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }
        static int GetMaxElFromPortion(int[] arr, int index)
        {
            int maxIndex = index;
            for (int i = index + 1; i < arr.Length; i++)
            {
                if (arr[i]>arr[maxIndex])
                {
                    maxIndex = i;
                }
            }
            return maxIndex;
        }
        static void SortArr(int[] arr)
        {
            //int[] sortedArr = new int[arr.Length];
            int maxIndex;
            for (int i = 0; i < arr.Length; i++)
            {
                maxIndex = GetMaxElFromPortion(arr, i);
                if (arr[maxIndex] > arr[i])
                {
                    Swap(arr, maxIndex, i);
                }
            }
            string descOrder = String.Join(", ", arr);
            Console.WriteLine("descOrder --> {0}", descOrder);
            Array.Reverse(arr);
            string ascOrder = String.Join(", ", arr);
            Console.WriteLine("ascOrder --> {0}", ascOrder);
            //return sortedArr;
        }
        static void Main()
        {
            int[] nums = {1, 2 ,5 ,0, 10, 6, 3, 4, 100};
            Console.WriteLine(String.Join(", ", nums));
            SortArr(nums);
           // Console.WriteLine(String.Join(", ", nums));
        }
    }
}
