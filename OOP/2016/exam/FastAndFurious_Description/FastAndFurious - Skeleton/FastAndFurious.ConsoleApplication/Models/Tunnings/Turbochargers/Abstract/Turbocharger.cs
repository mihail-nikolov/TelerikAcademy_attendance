using System;
using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Common.Utils;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Turbochargers.Abstract
{
    public abstract class Turbocharger : ITurbocharger, ITunningPart, IAccelerateable, ITopSpeed, IWeightable, IValuable 
    {
        public Turbocharger(decimal price, int weight , int acceleration, int topSpeed)
        {
            this.Price = price;
            this.Weight = weight;
            this.Acceleration = acceleration;
            this.TopSpeed = topSpeed;
            this.Id = DataGenerator.GenerateId();
        }

        public int Acceleration { get; protected set; }

        public TunningGradeType GradeType { get; protected set; }

        //private void SetTunningGradeType(string tunningGrade="")
        //{
        //    switch (tunningGrade)
        //    {
        //        case "HighGrade":
        //            this.GradeType = TunningGradeType.HighGrade;
        //            break;
        //        case "LowGrade":
        //            this.GradeType = TunningGradeType.LowGrade;
        //            break;
        //        case "MidGrade":
        //            this.GradeType = TunningGradeType.MidGrade;
        //            break;
        //        default:
        //            this.GradeType = TunningGradeType.NotSet;
        //            break;
        //    }
        //}

        public int Id { get; private set; }

        public decimal Price { get; protected set; }

        public int TopSpeed { get; protected set; }

        public TurbochargerType TurbochargerType { get; protected set; }

        public int Weight { get; protected set; }
    }
}
