using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPatternExample
{
    internal class Truck : Vehicle
    {
        public override void Display()
        {
            Console.WriteLine("This is a Truck.");
        }
    }
}
