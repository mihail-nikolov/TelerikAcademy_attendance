using System;

namespace circle_point
{
    class CirclePoint
    {
        static void Main()
        {
            double coordX = 0;
            double coordY = 0;
            double radius = 2;
            double polarCoordX = radius - coordX;
            double polarCoordY = radius - coordY;
            double pointX = -1.2;
            double pointY = -1.1;
            if (pointX > polarCoordX || pointY > polarCoordY)
            {
                if (pointX < -polarCoordX || pointY < -polarCoordY)
                {
                    Console.WriteLine(false);
                }
            }
            else
            {
                Console.WriteLine(true);
            }
        }
    }
}
