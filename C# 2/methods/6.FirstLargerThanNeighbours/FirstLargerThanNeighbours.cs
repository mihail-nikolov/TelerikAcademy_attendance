using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 6. First larger than neighbours

    Write a method that returns the index of the first element in array that is larger than its neighbours, or -1, if there’s no such element.
    Use the method from the previous exercise.
*/
namespace _6.FirstLargerThanNeighbours
{
    class FirstLargerThanNeighbours
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
        static int FirtLagrgerNeighbours(int[] arr)
        {
            int answer = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (LargerNeighbours(arr, i))
                {
                    answer = i;
                    return answer;
                }
            }
            return answer;
        }
        static void Main()
        {
            int[] arr = { 2, 10, 4, 5, 6, 8, 6, 2 };
            int answer = FirtLagrgerNeighbours(arr);
            Console.WriteLine(string.Join(", ", arr));
            Console.WriteLine("answer: {0}", answer);
        }
    }
}
