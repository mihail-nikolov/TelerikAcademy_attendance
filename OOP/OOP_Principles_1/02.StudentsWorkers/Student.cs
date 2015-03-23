using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.StudentsWorkers
{
    public class Student : Human
    {
        private double grade;

        public Student(string fname, string lname, double grade)
            : base(fname, lname)
        {
            this.Grade = grade;
        }
        public double Grade
        {
            get { return this.grade; }
            set
            {
                if (value < 2 || value > 6)
                {
                    throw new ArgumentException("grades [2; 6]");
                }
                this.grade = value; 
            }
        }
    }
}
