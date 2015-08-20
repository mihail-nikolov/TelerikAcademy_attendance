using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Students
{
    class Program
    {
        static void Main(string[] args)
        {
            Student mihail = new Student("Mihail", 10001);
            Course maths = new Course("maths");
            maths.Add(mihail);
            maths.Remove(mihail);
        }
    }
}
