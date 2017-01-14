using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 4. Binary search

    Write a program, that reads from the console an array of N integers and an integer K, sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K.
*/
namespace _4.BinarySearch
{
    class BinarySearch
    {
        static void Main()
        {
            Console.Write("N = ");
            int N = int.Parse(Console.ReadLine());
            Console.Write("K = ");
            int K = int.Parse(Console.ReadLine());
            int[] nums = new int[N];
            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write("Num{0} = ", i + 1);
                nums[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(nums);
            string sortedArr = string.Join(", ", nums);
            Console.WriteLine(sortedArr);
            int kIndex = Array.BinarySearch(nums, K);
            int searchedIndex = 0;
            //Console.WriteLine(kIndex);
            if (kIndex < 0)
            {
                searchedIndex = ~kIndex;
                if (searchedIndex == 0)
                {
                    Console.WriteLine("There are no elements smaller than K!");
                    return;
                }
                else
                {
                    searchedIndex = searchedIndex - 1;
                }
            }
            else
            {
                searchedIndex = kIndex;
            }
            Console.WriteLine("The largest number in the array which is <= K: {0}", nums[searchedIndex]);
        }
    }
}
