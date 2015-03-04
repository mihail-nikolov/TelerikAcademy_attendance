using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
/*Problem 17. Date in Bulgarian

    Write a program that reads a date and time given in the format: day.month.year hour:minute:second and prints the date and time after 6 hours and 30 minutes (in the same format) along with the day of week in Bulgarian.
*/
namespace _17.DateInBG
{
    class DateInBG
    {
        static void Main()
        {
            CultureInfo bulgarian = new CultureInfo("bg-BG");
            string input = Console.ReadLine(); // "27.02.2015 13:20:34";
            DateTime givenDate = DateTime.ParseExact(input, "dd.MM.yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime newDate = givenDate.AddHours(6.5);
            string dateToPrint = newDate.ToString("dd.MM.yyyy HH:mm:ss");

            string dayName = newDate.ToString("dddd", bulgarian);
            Console.WriteLine("{0} - {1}", dateToPrint, dayName);
        }
    }
}
