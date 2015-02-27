using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 16. Date difference

    Write a program that reads two dates in the format: day.month.year and calculates the number of days between them.
*/
namespace _16.DateDiff
{
    class DateDiff
    {
        static void Main()
        {
            Console.Write("enter d1 = ");
            string entD1 = Console.ReadLine();
            Console.Write("enter d2 = ");
            string entD2 = Console.ReadLine();
            DateTime d1 = DateTime.Parse(entD1);
            DateTime d2 = DateTime.Parse(entD2);
            TimeSpan days = (d1 - d2);
            double NrOfDays = Math.Abs(days.TotalDays);
            Console.WriteLine(NrOfDays);
        }
    }
}
