using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SchoolClasses
{
    public class Teacher : Human
    {
        private int number;
        private List<Discipline> disciplines;

        public Teacher(string name)
            :base(name)
        {
            this.Disciplines = new List<Discipline> { };
        }
        public List<Discipline> Disciplines
        {
            get { return this.disciplines; }
            set { this.disciplines = value; }
        }
    }
}
