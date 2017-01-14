using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPatternExample
{
    //public enum Type
    //{
    //    Front,
    //    TruckBed,
    //    TruckCab,
    //}

    //public enum Material
    //{
    //    Plastic,
    //    Fiberglass,
    //    Silicon,
    //    CarbonFiber
    //}
    internal class VehicleWithSpoiler : Decorator
    {
        public VehicleWithSpoiler(Vehicle vehicle) 
            :base(vehicle)
        {
            
        }

        public override void Display()
        {
            base.Display();

            Console.WriteLine(" ** tuned with Spoiler");
        }
    }
}
