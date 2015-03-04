using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;

/*Problem 19. Dates from text in Canada

    Write a program that extracts from a given text all dates that match the format DD.MM.YYYY.
    Display them in the standard date format for Canada.
*/
namespace _19.DatesFromTextInCanada
{
    class DatesFromTextInCanada
    {
        static void Main()
        {
            string text = "I was born at 14.06.1980. My sister was born at 3.7.1984. In 5/1999 I graduated my high school. The law says (see section 7.3.12) that we are allowed to do this (section 7.4.2.9). ";
            MatchCollection matches = Regex.Matches(text, @"\d{1,2}.\d{1,2}.\d{4}");
            CultureInfo canada = new CultureInfo("en-CA", false);
            List<string> foundDates = new List<string> { };
            foreach (Match match in matches)
            {
                foreach (Capture capture in match.Captures)
                {
                    foundDates.Add(capture.Value);
                    Console.WriteLine("{0}", capture.Value);
                }
            }
            for (int i = 0; i < foundDates.Count; i++)
            {
                DateTime foundDate = DateTime.ParseExact(foundDates[i], "d.M.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                Console.WriteLine(foundDate.ToString(canada));
            }
        }
    }
}
