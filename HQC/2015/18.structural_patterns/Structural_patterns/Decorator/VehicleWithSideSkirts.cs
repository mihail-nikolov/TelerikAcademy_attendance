using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPatternExample
{
    class VehicleWithSideSkirts : Decorator
    {
        public VehicleWithSideSkirts(Vehicle vehicle) 
            :base(vehicle)
        {
            
        }

        public override void Display()
        {
            base.Display();

            Console.WriteLine(" ** tuned with SideSkirts");
        }
    }
}
