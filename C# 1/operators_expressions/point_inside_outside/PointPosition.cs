using System;


namespace point_inside_outside
{
    class PointPosition
    {
        static bool isInCircle(double pointX, double pointY)
        {
            double circleCenterX = 1;
            double circleCenterY = 1;
            double radius = 1.5;
            double newPointX = Math.Abs(circleCenterX - pointX);
            double newPointY = Math.Abs(circleCenterY - pointY);
            if (newPointX <= radius && newPointY <= radius)
            {
                return true;
            }
            return false;
        }

        static bool isInRect(double pointX, double pointY)
        {
            double top = 1;
            double left = -1;
            double width = 6;
            double height = 2;
            double centerX = (left + width) / 2;
            double centerY = (top - height) / 2;
            double borderX = (centerX + width / 2);
            double borderY = (centerY + height / 2);
            double newPointX = Math.Abs(centerX - pointX);
            double newPointY = Math.Abs(centerY - pointY);
            if (newPointX <= borderX && newPointY <= borderY)
            {
                return true;
            }
            return false;
        }
        static void Main()
        {
            double pointX = 1;
            double pointY = 2.5;
            bool answer1 = PointPosition.isInCircle(pointX, pointY);
            bool answer2 = PointPosition.isInRect(pointX, pointY);
            Console.Write("Is the point inside the circle and outside the rect?:  ");
            if (answer1 && answer2 == false)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
