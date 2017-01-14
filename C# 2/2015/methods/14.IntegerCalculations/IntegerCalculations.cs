using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 14. Integer calculations

    Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers.
    Use variable number of arguments.
*/
namespace _14.IntegerCalculations
{
    class IntegerCalculations
    {
        static int[] calcMethod(int[] nums)
        {
            int[] output = new int[5];
            int max = nums.Max();
            int min = nums.Min();
            int sum = nums.Sum();
            int average = sum / nums.Length;
            int product = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                product *= nums[i];
            }
            output[0] = max;
            output[1] = min;
            output[2] = sum;
            output[3] = average;
            output[4] = product;
            return output;
        }
        static void Main()
        {
            Console.Write("enter how many nums do you want to add: ");
            int N = int.Parse(Console.ReadLine());
            int[] nums = new int[N];
            for (int i = 0; i < N; i++)
            {
                Console.Write("enter num = ");
                nums[i] = int.Parse(Console.ReadLine());
            }
            int[] output = calcMethod(nums);
            Console.WriteLine("max: {0}, min: {1}, sum: {2}, avrg: {3}, product: {4}", output[0], output[1], output[2], output[3], output[4]);
        }
    }
}
