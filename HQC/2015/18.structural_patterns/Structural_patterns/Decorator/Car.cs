using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPatternExample
{
    internal class Car : Vehicle
    {
        public override void Display()
        {
            Console.WriteLine("This is a Car");
        }
    }
}
