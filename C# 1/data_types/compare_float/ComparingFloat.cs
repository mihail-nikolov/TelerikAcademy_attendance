using System;


namespace compare_float
{
    class ComparingFloat
    {
        static void Main()
        {
            double a = 5.00000001f;
            double b = 5.00000003f;
            double eps = 0.000001f;
            double expected = Math.Abs(a - b);
            bool areEqual = expected < eps;
            Console.WriteLine(areEqual);

        }
    }
}
