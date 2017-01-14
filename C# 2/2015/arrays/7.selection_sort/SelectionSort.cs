using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Problem 7. Selection sort

    Sorting an array means to arrange its elements in increasing order. Write a program to sort an array.
    Use the Selection sort algorithm: Find the smallest element, move it at the first position, find the smallest from the rest, move it at the second position, etc.
*/  
namespace _7.selection_sort
{
    class SelectionSort
    {
        static void swap(int i, int j, int[] arr)
        {
            int tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 3, 8, 4, 2, 10, 20, 15, 13, 14, 16 };
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j]) 
                    {
                        SelectionSort.swap(i, j, arr);
                    }
                }
            }
            string strForPrint = string.Join(", ", arr);
            Console.WriteLine(strForPrint);
        }
    }
}
