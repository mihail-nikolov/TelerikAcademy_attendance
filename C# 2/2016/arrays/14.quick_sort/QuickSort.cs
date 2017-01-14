using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 14. Quick sort

    Write a program that sorts an array of strings using the Quick sort algorithm.
*/
namespace _14.quick_sort
{
    class QuickSort
    {
        static void swap(int[] arr, int i, int j)
        {
            int tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }
        static public int Partition(int[] nums, int left, int right)
        {
            int pivot = nums[left];
            while (true)
            {
                while (nums[left] < pivot)
                {
                    left++;
                }
                while (nums[right] > pivot)
                {
                    right--;
                }
                if (left < right)
                {
                    swap(nums, left, right);
                }
                else
                {
                    return right;
                }
            }
        }
        static public void quickSortMethod(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);
                if (pivot > 1)
                {
                    quickSortMethod(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    quickSortMethod(arr, pivot + 1, right);
                }
            }
        }
        static void Main()
        {
            int[] nums = { 1, 5, 2, 3, 10, 9, 8, 7 };
            quickSortMethod(nums, 0, nums.Length - 1);
            string strFortPrint = string.Join(", ", nums);
            Console.WriteLine(strFortPrint);
        }
    }
}
