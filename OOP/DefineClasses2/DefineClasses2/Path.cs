using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefineClasses
{
    public class Path
    {
        private List<Point3D> pathList;

        public Path()
        {
            this.PathList = new List<Point3D> { }; ;
        }
        public List<Point3D> PathList
        {
            get { return this.pathList; }
            set { this.pathList = value; }
        }
        public void AddPoint(Point3D point) 
        {
            this.PathList.Add(point);
        }
    }
}
