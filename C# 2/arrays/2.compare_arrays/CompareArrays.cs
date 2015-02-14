using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Problem 2. Compare arrays

    Write a program that reads two integer arrays from the console and compares them element by element.
*/
namespace _2.compare_arrays
{
    class CompareArrays
    {
        static string comparer(int n1, int n2)
        {
            string sign = "";
            if (n1 > n2)
            {
                sign = ">";
            }
            else if (n1 < n2)
            {
                sign = "<";
            }
            else
            {
                sign = "=";
            }
            return sign;
        }
        static void Main()
        {
            Console.Write("enter array 1: ");
            int[] arr1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Console.Write("enter array 2: ");
            int[] arr2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int minLenght = Math.Min(arr1.Length, arr2.Length);
            for (int i = 0; i < minLenght; i++)
            {
                string sign = CompareArrays.comparer(arr1[i], arr2[i]);
                Console.WriteLine("{0} {1} {2}", arr1[i],sign, arr2[i]);
            }
        }
    }
}
