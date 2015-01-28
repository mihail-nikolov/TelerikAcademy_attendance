using System;


namespace fibonacci_nums
{
    class fibonacci
    {

        static void Main()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            int[] fiboNums = new int[n];
            fiboNums[0] = 0;
            fiboNums[1] = 1;
            fiboNums[2] = 1;
            for (int i = 2; i < n; i++)
            {
                fiboNums[i] = fiboNums[i - 1] + fiboNums[i - 2];
            }
            Console.WriteLine(string.Join(", ", fiboNums));

        }
    }
}
