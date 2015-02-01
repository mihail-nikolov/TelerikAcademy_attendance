using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace random_nums_in_given_range
{
    class RanNumsRange
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int n = 3;
            int min = 0;
            int max = 5;
            if (min >= max)
            {
                Console.WriteLine("max > min !");
                return;
            }
            for (int i = 1; i <= n; i++)
            {
                int ranNumber = r.Next(min, max + 1);
                Console.WriteLine(ranNumber);
            }
        }
    }
}
