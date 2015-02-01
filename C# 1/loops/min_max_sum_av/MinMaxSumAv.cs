using System;


namespace min_max_sum_av
{
    class MinMaxSumAv
    {
        static void Main(string[] args)
        {
            int n;
            double max;
            double min;
            double sumArr = 0;
            double av;
            Console.Write("enter n = ");
            n = int.Parse(Console.ReadLine());
            double[] numsArr = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("num = ");
                double num = double.Parse(Console.ReadLine());
                numsArr[i] = num;
            }
            max = numsArr[0];
            min = numsArr[0];
            for (int i = 0; i <= numsArr.Length - 1; i++)
            {
                if (max < numsArr[i])
                {
                    max = numsArr[i];
                }
                if (min > numsArr[i])
                {
                    min = numsArr[i];
                }
                sumArr += numsArr[i];
            }
            av = sumArr / numsArr.Length;
            Console.WriteLine("max num is {0}", max);
            Console.WriteLine("min num is {0}", min);
            Console.WriteLine("sum is {0}", sumArr);
            Console.WriteLine("av is {0:F2}", av);

        }
    }
}
