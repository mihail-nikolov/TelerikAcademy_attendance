using System;

namespace Abstraction
{
    class Rectangle : Figure
    {
        public Rectangle()
            : base(0, 0)
        {
        }

        public Rectangle(double width, double height)
            : base(width, height)
        {
        }

        public override double CalcPerimeter()
        {
            return base.CalcPerimeter();
        }

        public override double CalcSurface()
        {
            return base.CalcSurface();
        }
    }
}
