using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SchoolClasses
{
    public class School
    {
        private string name;
        private List<SchoolClass> schoolClass;
        public School(string name)
        {
            this.SchoolClass = new List<SchoolClass> { };
            this.Name = name;        
        }
        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }
        public List<SchoolClass> SchoolClass
        {
            get { return this.schoolClass; }
            set { this.schoolClass = value; }
        }
    }
}
