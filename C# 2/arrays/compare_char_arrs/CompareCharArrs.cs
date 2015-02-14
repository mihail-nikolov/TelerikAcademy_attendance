using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Problem 3. Compare char arrays

    Write a program that compares two char arrays lexicographically (letter by letter).
*/
namespace compare_char_arrs
{
    class CompareCharArrs
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
            string arr1 = Console.ReadLine();
            Console.Write("enter array 2: ");
            string arr2 = Console.ReadLine();
            int minLenght = Math.Min(arr1.Length, arr2.Length);
            for (int i = 0; i < minLenght; i++)
            {
                string sign = CompareCharArrs.comparer(Convert.ToInt32(arr1[i]), Convert.ToInt32(arr2[i]));
                Console.WriteLine("{0} {1} {2}", arr1[i], sign, arr2[i]);
            }
        }
    }
}
