using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Shapes
{
    public abstract class Shape
    {
        double width;
        double height;

        public Shape(double width, double height)
        {
            this.width = width;
        }
        public virtual double CalculateSurface()
        {
            return this.height * this.width;
        }
    }
}
