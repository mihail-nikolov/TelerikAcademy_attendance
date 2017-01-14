using FastAndFurious.ConsoleApplication.Models.Tunnings.Turbochargers.Abstract;
using FastAndFurious.ConsoleApplication.Common.Enums;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Turbochargers
{
    public class VortexR35SequentialTurbocharger: Turbocharger
    {

        private const int price = 799;
        private const int weight = 3500;
        private const int acceleration = 15;
        private const int topSpeed = 60;

        public VortexR35SequentialTurbocharger()
            : base(price, weight, acceleration, topSpeed)
        {
            this.TurbochargerType = TurbochargerType.TwinTurbo;
            this.GradeType = TunningGradeType.HighGrade;
        }
    }
}
