using System;
using System.Collections.Generic;
/*
 * Problem 9. Matrix of Numbers

    Write a program that reads from the console a positive integer number n (1 ≤ n ≤ 20) and prints a matrix like in the examples below. Use two nested loops.
*/

namespace matrix_of_nums
{
    class MatrixNums
    {
        static void Main(string[] args)
        {
            Console.Write("enter n = ");
            int n = int.Parse(Console.ReadLine());
            if (n < 1 || n > 20)
            {
                Console.WriteLine("enter n between 1 and 20");
                return;
            }
            for (int i = 1; i <= n; i++)
            {
                for (int j = i; j <= n + i - 1; j++)
                {
                    Console.Write(j);
                }
                Console.WriteLine("\n");
            }
        }
    }
}
