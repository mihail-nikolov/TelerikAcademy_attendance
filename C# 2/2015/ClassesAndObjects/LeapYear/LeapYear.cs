using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 1. Leap year

    Write a program that reads a year from the console and checks whether it is a leap one.
    Use System.DateTime.
*/
namespace LeapYear
{
    class LeapYear
    {
        static void Main()
        {
            Console.Write("enter year: ");
            int theYear = int.Parse(Console.ReadLine());
            bool answer = DateTime.IsLeapYear(theYear);
            Console.WriteLine("the year is leap: {0}", answer);
        }
    }
}
