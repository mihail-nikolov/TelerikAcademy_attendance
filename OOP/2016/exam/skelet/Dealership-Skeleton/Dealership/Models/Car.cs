using Dealership.Common;
using Dealership.Common.Enums;
using Dealership.Contracts;
using Dealership.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Models
{
    public class Car : Vehicle, ICar
    {
        private const int wheels = 4;
        private int seats;

        public Car(string make, string model, decimal price, int seats) 
            : base(make, model, price, Car.wheels)
        {
            this.Seats = seats;
            this.Type = VehicleType.Car;
        }

        public int Seats
        {
            get
            {
                return this.seats;
            }
            private set
            {
                string exceptionMessage = string.Format(
                 Constants.NumberMustBeBetweenMinAndMax,
                 "Seats",
                 Constants.MinSeats,
                 Constants.MaxSeats);

                Validator.ValidateIntRange(
                    value,
                    Constants.MinSeats,
                    Constants.MaxSeats,
                    exceptionMessage
                    );
                this.seats = value;
            }
        }

        public override string ToString()
        {
            string seatsStr = string.Format("Seats: {0}", this.Seats);
            string baseStr = base.ToString();
            return string.Format(baseStr, seatsStr);
        }
    }
}
