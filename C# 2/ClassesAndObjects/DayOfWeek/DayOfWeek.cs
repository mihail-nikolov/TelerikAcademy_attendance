using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 3. Day of week

    Write a program that prints to the console which day of the week is today.
    Use System.DateTime.
*/
namespace DayOfWeek
{
    class DayOfWeek
    {
        static void Main()
        {
            DateTime today = DateTime.Now;
            Console.WriteLine(today.DayOfWeek);
        }
    }
}
