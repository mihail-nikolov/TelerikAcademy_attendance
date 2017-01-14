using FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles
{
    public class NissanGTR : MotorVehicle
    {
        private const decimal price = 125000;
        private const int weight = 1850000;
        private const int topSpeed = 300;
        private const int acceleration = 45;

        public NissanGTR()
                : base(NissanGTR.price, NissanGTR.weight, NissanGTR.topSpeed, NissanGTR.acceleration)
        {
        }
    }
}
