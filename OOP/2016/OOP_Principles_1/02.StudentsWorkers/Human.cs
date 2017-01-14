using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.StudentsWorkers
{
    public abstract class Human
    {
        private string fName;
        private string lName;

        public string FName
        {
            get { return this.fName;}
            set {this.fName = value;}
        }
        public string LName
        {
            get { return this.lName; }
            set { this.lName = value; }
        }

        public Human(string fname, string lname)
        {
            this.FName = fname;
            this.LName = lname;
        }
    }
}
