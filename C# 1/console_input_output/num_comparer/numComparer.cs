using System;


namespace num_comparer
{
    class numComparer
    {
        static void Main()
        {
            Console.Write("a = ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b = ");
            double b = double.Parse(Console.ReadLine());
            if (a >= b)
            {
                Console.WriteLine("greater num is: {0}", a);
            }
            else
            {
                Console.WriteLine("greater num is: {0}", b);
            }

        }
    }
}
