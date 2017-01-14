using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 1. StringBuilder.Substring

    Implement an extension method Substring(int index, int length) for the class StringBuilder that returns new StringBuilder and has the same functionality as Substring in the class String.

Problem 2. IEnumerable extensions

    Implement a set of extension methods for IEnumerable<T> that implement the following group functions: sum, product, min, max, average.
Problem 4. Age range

    Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.

Problem 5. Order students

    Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first name and last name in descending order.
    Rewrite the same with LINQ.
 * Problem 6. Divisible by 7 and 3

    Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.

 */
namespace Ext_Delegates_Lambda_Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder strB = new StringBuilder("abcsdsasda asda asd ");
            StringBuilder newSB = strB.Substring(4, 10);
            Console.WriteLine(newSB);
            int[] arr = new int[]{1, 2, 3, 4, 5, 6, 7, 8, 21};
            Console.WriteLine(arr.Max());
            Console.WriteLine(arr.Min());
            Console.WriteLine(arr.Sum());
            Console.WriteLine(arr.Product());
            Console.WriteLine(arr.Average());

            int[] newArr = arr.ToList().FindAll(x => x % 7 == 0 && x % 3 == 0).ToArray();
            newArr.Foreach();

            var myNewArr =
                from num in arr
                where num % 7 == 0 && num % 3 == 0
                select num;
            myNewArr.Foreach();

            string[] str = new string[]{ "abv", "adasa", "asdadasdasdas" };
            str.LongestStr();
        }
    }
}
