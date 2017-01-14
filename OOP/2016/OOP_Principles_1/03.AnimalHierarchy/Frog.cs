using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.AnimalHierarchy
{
    public class Frog:Animal, ISound
    {
        public Frog(string name, char sex, int age)
            : base(name, sex, age)
        {

        }
        public void MakeSoud()
        {
            Console.WriteLine("kvak");
        }
    }
}
