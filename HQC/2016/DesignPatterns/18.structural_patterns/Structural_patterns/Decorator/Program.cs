using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPatternExample
{
    class Program
    {
        static void Main()
        {
            var car = new Car();
            car.Display();
            Console.WriteLine("-------- Tunning the car --------");
            var tuningCar = new VehicleWithSpoiler(car);
            tuningCar.Display();

            var truck = new Truck();
            truck.Display();
            Console.WriteLine("-------- Tunning the truck --------");
            var tuningTruck = new VehicleWithSideSkirts(truck);
            tuningTruck.Display();
        }
    }
}
