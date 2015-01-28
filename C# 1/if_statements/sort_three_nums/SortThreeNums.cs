using System;


namespace sort_three_nums
{
    class SortThreeNums
    {
        static void Swap<T>(ref T x, ref T y)
        {
            T t = y;
            y = x;
            x = t;
        }
        static void Main()
        {
            
            Console.Write("a = ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b = ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("c = ");
            double c = double.Parse(Console.ReadLine());
            if (a < b)
            {
                SortThreeNums.Swap(ref a, ref b);

                if (a < c)
                {
                    SortThreeNums.Swap(ref a, ref c);
                }
            }
            if (a < c)
            {
                SortThreeNums.Swap(ref a, ref c);

            }
            if (b < c)
            {
                SortThreeNums.Swap(ref b, ref c);
            }
            Console.WriteLine("sorted nums are {0}, {1}, {2}", a, b, c);

        }
    }
}
