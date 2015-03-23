using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.AnimalHierarchy
{
    public class Cat : Animal, ISound
    {
        public Cat(string name, char sex, int age)
            : base(name, sex, age)
        {

        }
        public Cat(string name, int age)
            :base(name, age)
        {
            
        }

        public void MakeSoud()
        {
            Console.WriteLine("mau");
        }
    }
}
