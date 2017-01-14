using Dealership.Common;
using Dealership.Common.Enums;
using Dealership.Contracts;
using Dealership.Models.Abstract;

namespace Dealership.Models
{
    public class Truck : Vehicle, ITruck
    {
        private const int wheels = 8;
        private const int minWeightCapacity = 1;
        private const int maxWeightCapacity = 100;
        private int weightCapacity;

        public Truck(string make, string model, decimal price, int weightCapacity)
            : base(make, model, price, Truck.wheels)
        {
            this.WeightCapacity = weightCapacity;
            this.Type = VehicleType.Truck;
        }

        public int WeightCapacity
        {
            get
            {
                return this.weightCapacity;
            }

            private set
            {
                string exceptionMessage = string.Format(
                 Constants.NumberMustBeBetweenMinAndMax,
                 "Weight capacity",
                 Truck.minWeightCapacity,
                 Truck.maxWeightCapacity);

                Validator.ValidateIntRange(
                    value,
                    Truck.minWeightCapacity,
                    Truck.maxWeightCapacity,
                    exceptionMessage
                    );
                this.weightCapacity = value;
            }
        }

        public override string ToString()
        {
            string weightStr = string.Format("Weight Capacity: {0}t", this.WeightCapacity);
            string baseStr = base.ToString();
            return string.Format(baseStr, weightStr);
        }
    }
}
