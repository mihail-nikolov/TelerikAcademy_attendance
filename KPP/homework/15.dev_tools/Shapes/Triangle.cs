using System;
using System.Linq;
                    
namespace Shapes
{
   /// <summary>
    /// This class contains properties & method to calculate the surface for right-angled triangle.
    /// The right-angle is between -a- and -b-
   /// </summary>
    public class Triangle : Shape
    {
        /// <summary>
        /// triangle constructor - inherits SHAPE. Dimensions - whatever you choose. 
        /// </summary>
        /// <param name="height">One side of triangle (a)</param>
        /// <param name="width">The side of triangle (b)</param>
        public Triangle(double height, double width) :
            base(width, height) { }
        /// <summary>
        /// Calculating the surface. Overriding Shape.CalculateSurface method
        /// </summary>
        /// <returns>Returns the calculated surface in dimensions you chose, entering -a-b-</returns>
        public override double CalculateSurface()
        {
            return base.CalculateSurface()/2;
        }
    }
}
