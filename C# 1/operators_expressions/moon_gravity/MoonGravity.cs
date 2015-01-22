using System;


namespace moon_gravity
{
    class MoonGravity
    {
        static void Main()
        {
            double weight = 65.3;
            double moonWeight = weight * 0.17;
            Console.WriteLine("your Earth weight is {0} and your Moon Weight is {1}", weight, moonWeight);
        }
    }
}
