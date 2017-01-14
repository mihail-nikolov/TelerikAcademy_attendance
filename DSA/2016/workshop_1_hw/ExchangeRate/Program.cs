using System;
using System.Globalization;
using System.Threading;

namespace ExchangeRate
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            double currency1 = double.Parse(Console.ReadLine());
            double currency2 = 0;
            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                var currency = Console.ReadLine().Split(' ');
                var rate12 = double.Parse(currency[0]);
                var rate21 = double.Parse(currency[1]);

                var updatedCurrency2 = rate12 * currency1;
                var updatedCurrency1 = rate21 * currency2;

                currency1 = Math.Max(currency1, updatedCurrency1);
                currency2 = Math.Max(currency2, updatedCurrency2);
            }

            Console.WriteLine("{0:0.00}",currency1);
        }
    }
}
