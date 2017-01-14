using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTypeSystem
{
    class Person
    {
        private string name;
        private uint? age;
        public Person(string name, uint? age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty!");
                }
                this.name = value;
            }
        }
        public uint? Age
        {
            get;
            set;
        }
        public override string ToString()
        {
            string ageAnswer = "";
            if (this.Age.HasValue)
            {
                ageAnswer = this.Age.ToString();
            }
            else
            {
                ageAnswer = "no info";
            }
            return string.Format(@"Name: {0}, Age: {1}", this.Name, ageAnswer);
        }
    }
}
