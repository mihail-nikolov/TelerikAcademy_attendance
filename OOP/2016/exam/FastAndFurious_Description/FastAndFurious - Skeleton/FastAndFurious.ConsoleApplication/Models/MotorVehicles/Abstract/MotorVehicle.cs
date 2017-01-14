using System;
using System.Collections.Generic;
using System.Linq;
using FastAndFurious.ConsoleApplication.Common.Constants;
using FastAndFurious.ConsoleApplication.Common.Exceptions;
using FastAndFurious.ConsoleApplication.Common.Utils;
using FastAndFurious.ConsoleApplication.Contracts;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract
{
    public abstract class MotorVehicle : IMotorVehicle, IWeightable, IValuable
    {
        private decimal price;
        private List<ITunningPart> tunningParts;

        public MotorVehicle(decimal price, int weight, int topSpeed, int acceleration)
        {
            this.Id = DataGenerator.GenerateId();
            this.Price = price;
            this.Weight = weight;
            this.TopSpeed = TopSpeed;
            this.Acceleration = acceleration;
            this.tunningParts = new List<ITunningPart>();
            // All of these stuff could be added in Common folder in common abstract class, but not time :)
        }

        public decimal Price
        {
            get
            {
                return this.price + this.TunningParts.Sum(x => x.Price);
            }
            protected set
            {
                this.price = value;
            }
        }
        public int Weight { get; protected set; }
        public int Acceleration { get; protected set; }
        public int TopSpeed { get; protected set; }
        public IEnumerable<ITunningPart> TunningParts
        {
            get
            {
                return new List<ITunningPart>(this.tunningParts);
            }
        }
        public int Id { get; protected set; }

        public void AddTunning(ITunningPart part)
        {
            this.tunningParts.Add(part);
        }
        public TimeSpan Race(int trackLengthInMeters)
        {
            //return (trackLengthInMeters / this.TopSpeed);
            throw new NotImplementedException();
        }
        public bool RemoveTunning(ITunningPart part)
        {
            if (this.tunningParts.Contains(part))
            {
                this.tunningParts.Remove(part);
                return true;
            }
            return false;
        }
    }
}
