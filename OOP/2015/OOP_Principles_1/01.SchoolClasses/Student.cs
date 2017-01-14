using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SchoolClasses
{
    public class Student : Human
    {
        private int number;

        public Student(string name, int number)
            :base(name)
        {
            this.Number = number;
        }
        public int Number
        {
            get { return this.number; }
            private set { this.number = value; }
        }
    }
}
