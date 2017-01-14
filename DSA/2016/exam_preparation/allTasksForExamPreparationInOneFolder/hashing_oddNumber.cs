using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01OddNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            long result = 0;
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                result ^= long.Parse(Console.ReadLine());
            }

            //ISet<long> numbers = new HashSet<long>();
            //for (int i = 0; i < n; i++)
            //{
            //    long curNum = long.Parse(Console.ReadLine());
            //    if (numbers.Contains(curNum))
            //    {
            //        numbers.Remove(curNum);
            //    }
            //    else
            //    {
            //        numbers.Add(curNum);
            //    }
            //}
            //result = numbers.First();

            Console.WriteLine(result);
        }
    }
}
