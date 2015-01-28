using System;
using System.Globalization;
using System.Threading;


namespace beers
{
    class Beers
    {
        static void Main()
        {
            Console.Write("Enter Time in format <hh:mm tt>: ");
            string theTime = Console.ReadLine();
            DateTime time = new DateTime();
            string answer;
            bool invalidInput = DateTime.TryParseExact(theTime, "h:mm tt", System.Globalization.CultureInfo.InvariantCulture, DateTimeStyles.None, out time);
            if (invalidInput)
            {
                time = DateTime.ParseExact(theTime, "h:mm tt", System.Globalization.CultureInfo.InvariantCulture);
                DateTime start = DateTime.ParseExact("1:00 PM", "h:mm tt", System.Globalization.CultureInfo.InvariantCulture);
                DateTime end = DateTime.ParseExact("3:00 AM", "h:mm tt", System.Globalization.CultureInfo.InvariantCulture);
                if ((time >= start) && (time >= end))
                {
                    answer = "beer time";
                }
                else if (time <= end)
                {
                    answer = "beer time";
                }
                else
                {
                    answer = "non-beer time";
                }
            }
            else
            {
                answer = "invalid time";
                
            }
            Console.WriteLine(answer);
        }
    }
}
