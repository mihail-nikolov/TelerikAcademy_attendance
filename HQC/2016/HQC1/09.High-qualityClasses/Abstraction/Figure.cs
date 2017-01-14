using System;

namespace Abstraction
{
    abstract class Figure
    {
        private double width;
        private double height;
        public Figure()
        {
        }
        public Figure(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public virtual double Width
        {
            get { return this.width; }
            internal set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Width must be > 0!");
                }
                this.width = value;
            }
        }
        public virtual double Height
        {
            get { return this.height; }
            internal set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Height must be > 0!");
                }
                this.height = value;
            }
        } 

        public virtual double CalcPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public virtual double CalcSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}
