using System;
using System.Linq;

namespace Shapes
{
    public class Square : Rect
    {
        public Square(double side) :
            base(side, side) { }
    }
}
