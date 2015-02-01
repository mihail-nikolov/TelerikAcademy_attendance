using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Problem 12.* Randomize the Numbers 1…N

    Write a program that enters in integer n and prints the numbers 1, 2, …, n in random order.
*/

namespace randomize_nums_to_n
{
    class RandomizeNums
    {
        static void Main(string[] args)
        {
            int n = 10;
            List<int> numsList = new List<int>(n);
            for (int i = 1; i < n; i++)
            {
                numsList.Add(i);
            }
            Random r = new Random();
            while (numsList.Count > 0)
            {
                int index = r.Next(numsList.Count);
                Console.WriteLine(numsList[index]);
                numsList.RemoveAt(index);
            }
        }
    }
}
