using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class University:IInstitution
    {

        
        private string name;
        private List<int> marks = new List<int>{ 3, 2, 5, 4, 5, 6, 6, 6, 4 };
        private string[] students = new string[] { "goshko", "pesho", "pehata", "huan" };
        private string[] teachers = new string[] { "goshko", "pesho", "pehata", "huan" };
        public University(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public string[] Students
        {
            get { return this.students; }
        }

        public string[] Teachers
        {
            get { return this.teachers; }
        }
        public List<int> Marks
        {
            get { return this.marks; }
        }
    }
}
