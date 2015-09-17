using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPatternExample
{
    /// <summary>
    /// The 'Decorator' abstract class
    /// </summary>
    internal abstract class Decorator : Vehicle
    {
        protected Vehicle Vehicle { get; private set; }
        protected Decorator(Vehicle vehicle)
        {
            this.Vehicle = vehicle;
        }

        public override void Display()
        {
            this.Vehicle.Display();
        } 
    }
}
