using System;


namespace quotes
{
    class QuotesStrings
    {
        static void Main()
        {
            string one = @"The ""use"" of quotations causes difficulties";
            string two = "The \"use\" of quotations causes difficulties";
            Console.WriteLine("first: {0}\nsecond:{1}", one, two);
        }
    }
}
