using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 5. Larger than neighbours

    Write a method that checks if the element at given position in given array of integers is larger than its two neighbours (when such exist).
*/
namespace _5.LargerThanNeighbours
{
    class LargerThanNeightours
    {
        static bool LargerNeighbours(int[] arr, int pos)
        {
            if (pos <= 0 || pos >= arr.Length - 1)
            {
                return false;
            }
            if (arr[pos] > arr[pos + 1] && arr[pos] > arr[pos - 1])
            {
                return true;
            }
            return false;
        }
        static void Main()
        {
            int[] arr = { 2, 3, 4, 5, 6, 8, 6, 2 };
            int pos = 5;
            bool answer = LargerNeighbours(arr, pos);
            Console.WriteLine(string.Join(", ", arr));
            Console.WriteLine("the num {0} on index {1} is larger than neighbours: {2}",arr[pos], pos, answer);
        }
    }
}
