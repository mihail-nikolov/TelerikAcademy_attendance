using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    class Program
    {
        static void Main()
        {
            RentableVehicles myRentables = new RentableVehicles();
            Car myCar = new Car("Ford Fiesta");
            Bicycle myBike = new Bicycle();

            myRentables.Attach(myCar);
            myRentables.Attach(myBike);

            myRentables.Accept(new TiresMaintainer());
            myRentables.Accept(new WashMaintainer());
        }
    }
}
