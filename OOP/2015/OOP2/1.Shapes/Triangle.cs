using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Shapes
{
    public class Triangle : Shape
    {
        public Triangle(double height, double width) :
            base(width, height) { }

        public override double CalculateSurface()
        {
            return base.CalculateSurface()/2;
        }
    }
}
