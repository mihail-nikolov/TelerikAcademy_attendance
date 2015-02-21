using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;
using System.Threading;
/*Problem 15.* Number calculations

    Modify your last program and try to make it work for any number type, not just integer (e.g. decimal, float, byte, etc.)
    Use generic method (read in Internet about generic methods in C#).
*/
namespace _15.NumberCalculations
{
    class NumberCalculations
    {
        static T[] calcMethod<T>(T[] nums)
        {
            var output = new T[5];
            var max = nums.Max();
            var min = nums.Min();
            dynamic sum = 0;
            dynamic product = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                product *= nums[i];
                sum += nums[i];
            }
            var average = sum / nums.Length;
            output[0] = max;
            output[1] = min;
            output[2] = sum;
            output[3] = average;
            output[4] = product;
            return output;
        }
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Console.Write("enter how many nums do you want to add: ");
            double[] nums = { 2.0, 5, 8, 19, 12.4324 };
            double[] output = calcMethod(nums);
            Console.WriteLine("max: {0}, min: {1}, sum: {2}, avrg: {3}, product: {4}", output[0], output[1], output[2], output[3], output[4]);
        }
    }
}
