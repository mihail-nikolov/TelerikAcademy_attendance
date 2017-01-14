using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    public class TiresMaintainer : IMaintainable
    {
        public void Maintain(Vehicle vehicle)
        {
            Console.WriteLine("Changing tires of {0}...", vehicle.GetType().Name);
        }
    }
}
