using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Students
{
    public class Student
    {
        private string name;
        private int uniqeNum; 

        public Student(string name, int id)
        {
            this.Name = name;
            this.UniqueNumber = id;
           
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value == "")
                {
                    throw new ArgumentException("empty string!");
                }
                this.name = value;
            }
        }
        public int UniqueNumber
        {
            get
            {
                return this.uniqeNum;
            }
            private set
            {
                if (value > 99999 || value < 10000)
                {   
                    throw new ArgumentException("no place for more students in the schools");
                }
                this.uniqeNum = value;

            }
        }
    }
}
