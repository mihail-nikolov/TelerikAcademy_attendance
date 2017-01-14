using FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles
{
    public class SubaruImprezaWRX : MotorVehicle
    {
        private const decimal price = 55999;
        private const int weight = 1560000;
        private const int topSpeed = 260;
        private const int acceleration = 35;

        public SubaruImprezaWRX() 
            : base(SubaruImprezaWRX.price, SubaruImprezaWRX.weight, SubaruImprezaWRX.topSpeed, SubaruImprezaWRX.acceleration)
        {
        }
    }
}
