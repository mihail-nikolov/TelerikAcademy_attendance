using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 Problem 4. Triangle surface

    Write methods that calculate the surface of a triangle by given:
        Side and an altitude to it;
        Three sides;
        Two sides and an angle between them;
    Use System.Math.
*/
namespace _4.TriangleSurface
{
    class TriangleSurface
    {
        static double SideAltitude(double a, double ha)
        {
            double area = (a * ha) / 2;
            return area;
        }
        static double ThreeSides(double a, double b, double c)
        {
            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s*(s-a)*(s-b)*(s-c));
            return area;
        }
        static double TwoSidesAngle(double a, double b, double ab)
        {
            double area = a*b*Math.Sin(ab* Math.PI/180)/2;
            return area;
        }
        static void Main()
        {
            double a = 3;
            double b = 4;
            double c = 5;
            double ha = 2;
            double ab = 90;
            Console.WriteLine(TwoSidesAngle(a, b, ab).ToString());
            Console.WriteLine(SideAltitude(a, ha).ToString());
            Console.WriteLine(ThreeSides(a, b, c).ToString());
        }
    }
}
