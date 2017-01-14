using FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles
{
    public class AcuraIntegraTypeR : MotorVehicle
    {
        private const decimal price = 24999;
        private const int weight = 1700000;
        private const int topSpeed = 200;
        private const int acceleration = 15;

        public AcuraIntegraTypeR() 
            : base(AcuraIntegraTypeR.price, AcuraIntegraTypeR.weight, AcuraIntegraTypeR.topSpeed, AcuraIntegraTypeR.acceleration)
        {
        }
    }
}
