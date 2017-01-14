using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class School:IInstitution
    {

        private string name;
        private int[] marks = new int[] { 2, 6, 3, 4, 5 , 6 ,5 , 2, 4};
        private string[] students = new string[] { "goshko", "pesho", "pehata", "huan" };

        public School(string name)
        {
            this.Name = name;
        }
        private string[] teachers = new string[] { "goshko", "pesho", "pehata", "huan" };
        public string[] Students
        {
            get { return this.students; }
        }
        
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public string[] Teachers
        {
            get { return this.teachers; }
        }
        public int[] Marks
        {
            get { return this.marks; }
        }
    }
}
