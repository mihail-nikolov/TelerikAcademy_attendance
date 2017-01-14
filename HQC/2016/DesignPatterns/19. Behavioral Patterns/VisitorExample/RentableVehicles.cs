using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    //The 'Object Structure' class
    public class RentableVehicles
    {
        private List<Vehicle> vehicles = new List<Vehicle>();

        public void Attach(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
        }

        public void Detach(Vehicle vehicle)
        {
            vehicles.Remove(vehicle);
        }

        public void Accept(IMaintainable maintainer)
        {

            foreach (Vehicle v in vehicles)
            {
                v.Accept(maintainer);
            }

            Console.WriteLine();

        }
    }
}
