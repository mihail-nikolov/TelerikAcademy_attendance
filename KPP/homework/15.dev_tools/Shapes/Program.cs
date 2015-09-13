using System;
using System.Collections.Generic;
using System.Linq;
/*Problem 1. Shapes

    Define abstract class Shape with only one abstract method CalculateSurface() and fields width and height.
    Define two new classes Triangle and Rectangle that implement the virtual method and return the surface of the figure (heightwidth for rectangle and heightwidth/2 for triangle).
    Define class Square and suitable constructor so that at initialization height must be kept equal to width and implement the CalculateSurface() method.
    Write a program that tests the behaviour of the CalculateSurface() method for different shapes (Square, Rectangle, Triangle) stored in an array.
*/
namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Rect rect1 = new Rect(2, 3);

            Square sq1 = new Square(4);

            Triangle tr1 = new Triangle(4, 5);

            List<Shape> shapes = new List<Shape> { };
            shapes.Add(rect1);
            shapes.Add(sq1);
            shapes.Add(tr1);

            shapes.ForEach(el => Console.WriteLine("Surface {0} = {1}", el.GetType().Name, el.CalculateSurface()));

        }
    }
}
