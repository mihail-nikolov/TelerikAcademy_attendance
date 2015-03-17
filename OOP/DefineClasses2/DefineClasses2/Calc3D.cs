using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefineClasses
{
    public static class Calc3D
    {
        public static double GetDistance(Point3D point1, Point3D point2)
        {
            double distance = Math.Sqrt(Math.Pow((point1.X - point2.X), 2)
                + Math.Pow((point1.Y - point2.Y), 2)
                + Math.Pow((point1.Z - point2.Z), 2));
            return distance;
        }
    }
}
