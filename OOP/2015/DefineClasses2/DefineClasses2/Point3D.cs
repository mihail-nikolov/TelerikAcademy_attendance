using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefineClasses
{
    public struct Point3D
    {
        private double x;
        private double y;
        private double z;
        private static readonly Point3D O_POINT = new Point3D(0, 0, 0);

        public static Point3D OPoint
        {
            get { return O_POINT; }
        }
        public Point3D(double x, double y, double z)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
        public double X 
        {
            get {return this.x;}
            set{this.x = value;}
        }
        public double Y
        {
            get { return this.y; }
            set { this.y = value; }
        }
        public double Z
        {
            get { return this.z; }
            set { this.z = value; }
        }

        public override string ToString()
        {
            return string.Format(@"X: {0}, Y: {1}, Z: {2}", this.X, this.Y, this.Z);                         
        }
    }
}
