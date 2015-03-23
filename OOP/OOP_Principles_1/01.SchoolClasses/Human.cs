using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SchoolClasses
{
    public class Human
    {
        private string name;

        public Human(string name)
        {
            this.Name = name;
        }
        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }
    }
}
