using System;

namespace circle_per_area
{
    class circlePerArea
    {
        static void Main()
        {
            Console.Write("r = ");
            double r = double.Parse(Console.ReadLine());
            double area = Math.PI * Math.Pow(r, 2);
            double perimeter = Math.PI * 2 * r;
            Console.WriteLine("area = {0:F2}", area);
            Console.WriteLine("per = {0:F2}", perimeter);
        }
    }
}
