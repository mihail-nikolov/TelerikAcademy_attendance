using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastAndFurious.ConsoleApplication.Common.Enums;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Turbochargers.Abstract
{
    public class ZX8ParallelTwinTurbocharger : Turbocharger
    {
        private const int price = 699;
        private const int weight = 3900;
        private const int acceleration = 10;
        private const int topSpeed = 85;

        public ZX8ParallelTwinTurbocharger()
            : base(price, weight, acceleration, topSpeed)
        {
            this.TurbochargerType = TurbochargerType.SequentialTurbo;
            this.GradeType = TunningGradeType.HighGrade;
        }
    }
}
