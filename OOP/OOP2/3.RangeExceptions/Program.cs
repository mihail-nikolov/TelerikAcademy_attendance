using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Problem 3. Range Exceptions

    Define a class InvalidRangeException<T> that holds information about an error condition related to invalid range. It should hold error message and a range definition [start … end].
    Write a sample application that demonstrates the InvalidRangeException<int> and InvalidRangeException<DateTime> by entering numbers in the range [1..100] and dates in the range [1.1.1980 … 31.12.2013].
*/
namespace _3.RangeExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("num: ");
            try
            {
                int number = int.Parse(Console.ReadLine());
                int start = 1;
                int end = 100;
                if (number < start || number > end)
                {
                    throw new InvalidRangeException<int>("Out of range!", start, end);
                }
                Console.WriteLine("next line");
            }
            catch (InvalidRangeException<int> ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Write("date: ");
            try
            {
                string line = Console.ReadLine();
                DateTime date = DateTime.Parse(line);
                DateTime start = DateTime.Parse("1.1.1980");
                DateTime end = DateTime.Parse("31.12.2013");
                if (date < start || date > end)
                {
                    throw new InvalidRangeException<DateTime>("Out of range!", start, end);
                }
                Console.WriteLine("next line");
            }
            catch (InvalidRangeException<DateTime> ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
