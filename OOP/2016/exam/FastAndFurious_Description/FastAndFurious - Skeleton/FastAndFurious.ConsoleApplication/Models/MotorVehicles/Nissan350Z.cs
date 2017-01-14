using FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles
{
    public class Nissan350Z : MotorVehicle
    {
        private const decimal price = 25999;
        private const int weight = 1280000;
        private const int topSpeed = 220;
        private const int acceleration = 55;

        public Nissan350Z()
                : base(Nissan350Z.price, Nissan350Z.weight, Nissan350Z.topSpeed, Nissan350Z.acceleration)
        {
        }
    }
}
