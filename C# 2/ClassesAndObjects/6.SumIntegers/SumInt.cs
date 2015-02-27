using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 Problem 6. Sum integers

    You are given a sequence of positive integer values written into a string, separated by spaces.
    Write a function that reads these values from given string and calculates their sum.

Example:*/
namespace _6.SumIntegers
{
    class SumInt
    {
        static void Main()
        {
            Console.Write("enter nums splitted by spaces:");
            string numsStr = Console.ReadLine();
            int[] arr = numsStr.Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
            Console.WriteLine(arr.Sum().ToString());
        }
    }
}
