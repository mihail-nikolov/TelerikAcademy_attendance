using System;

namespace Abstraction
{
    class Circle : Figure
    {
        private double radius;
        public double Radius
        {
            get { return this.radius; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Radius must be > 0!");
                }
                this.radius = value;
            }
        }

        public override double Width
        {
            get
            {
                throw new NotImplementedException("Circle does not have Width");
            }
            internal set
            {
                throw new NotImplementedException("Circle does not have Width");
            }
        }
        public override double Height
        {
            get
            {
                throw new NotImplementedException("Circle does not have Width");
            }
            internal set
            {
                throw new NotImplementedException("Circle does not have Width");
            }
        } 
        public Circle()
            :base()
        {
        }

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}
