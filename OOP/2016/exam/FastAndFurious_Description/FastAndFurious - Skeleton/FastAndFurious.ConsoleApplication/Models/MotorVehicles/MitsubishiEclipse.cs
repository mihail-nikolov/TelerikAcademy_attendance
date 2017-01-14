using FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles
{
    public class MitsubishiEclipse : MotorVehicle
    {
        private const decimal price = 29999;
        private const int weight = 1400000;
        private const int topSpeed = 230;
        private const int acceleration = 24;

        public MitsubishiEclipse()
                : base(MitsubishiEclipse.price, MitsubishiEclipse.weight, MitsubishiEclipse.topSpeed, MitsubishiEclipse.acceleration)
        {
        }
    }
}
