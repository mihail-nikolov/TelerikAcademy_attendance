using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SchoolClasses
{
    public class Discipline
    {
        private string name;
        private int exercises;
        private int lectures;

        public Discipline(string name, int exercises, int lectures)
        {
            this.Name = name;
            this.Exercises = exercises;
            this.Lectures = lectures;
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public int Exercises
        {
            get { return this.exercises; }
            set { this.exercises = value; }
        }
        public int Lectures
        {
            get { return this.lectures; }
            set { this.lectures = value; }
        }
    }
}
