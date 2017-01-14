using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;
/*
 Problem 5. Workdays

    Write a method that calculates the number of workdays between today and given date, passed as parameter.
    Consider that workdays are all days from Monday to Friday except a fixed list of public holidays specified preliminary as array.
*/
namespace _5.Workdays
{
    class Workdays
    {
        static string[] HOLIDAYS = { "2015-03-02", "2015-03-03" };
        static int GetWorkingDays(DateTime now, DateTime endDate)
        {
            int counter = 0;
            int DayInterval = 1;
            while (now.AddDays(DayInterval) <= endDate)
            {
                now = now.AddDays(DayInterval);
                string nowStr = now.ToString("yyyy-MM-dd");
                if (!HOLIDAYS.Contains(nowStr))
                {
                    string todayOfWeek = now.DayOfWeek.ToString();
                    Console.WriteLine(todayOfWeek);
                    if (todayOfWeek != "Saturday" && todayOfWeek != "Sunday")
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }
        static void Main()
        {
            Console.Write("enter future date(yyyy-mm-dd): ");
            string givenDate = Console.ReadLine();
            DateTime ednDate = DateTime.ParseExact(givenDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime now = DateTime.Now;
            int workingDays = GetWorkingDays(now, ednDate);
            Console.WriteLine(workingDays);
            DateTime blq = new DateTime(2015, 03, 03);
            //bool isHoliday = HOLIDAYS.Contains(now);
            //Console.WriteLine(isHoliday);
            // Console.WriteLine(nowDate);
            // Console.WriteLine(futTime);
        }
    }
}
