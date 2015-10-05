using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    public class WashMaintainer : IMaintainable
    {
        public void Maintain(Vehicle vehicle)
        {
            Console.WriteLine("Washing {0}...", vehicle.GetType().Name);
        }
        
    }
}
