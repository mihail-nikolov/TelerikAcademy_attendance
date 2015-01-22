using System;


namespace rectangles
{
    class Rectangle
    {
        static void Main()
        {
            double width = 5;
            double height = 10;
            double area = width * height;
            double perimeter = 2 * (width + height);
            Console.WriteLine("the area is: {0}",area);
            Console.WriteLine("the perimeter is: {0}", perimeter);
        }
    }
}
