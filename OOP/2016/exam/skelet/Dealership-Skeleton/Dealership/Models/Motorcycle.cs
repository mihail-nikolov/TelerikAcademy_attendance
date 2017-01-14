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
    public class Motorcycle : Vehicle, IMotorcycle
    {
        private const int wheels = 2;
        private string category;

        public Motorcycle(string make, string model, decimal price, string category) 
            : base(make, model, price, Motorcycle.wheels)
        {
            this.Category = category;
            this.Type = VehicleType.Motorcycle;
        }

        public string Category
        {
            get
            {
                return this.category;
            }
            private set
            {
                string exceptionMessage = string.Format(
                    Constants.StringMustBeBetweenMinAndMax,
                    "Category",
                    Constants.MinCategoryLength,
                    Constants.MaxCategoryLength);

                Validator.ValidateIntRange(
                    value.Length,
                    Constants.MinCategoryLength,
                    Constants.MaxCategoryLength,
                    exceptionMessage
                    );
                this.category = value;
            }
        }

        public override string ToString()
        {
            string categoryStr = string.Format("Category: {0}", this.Category);
            string baseStr = base.ToString();
            return string.Format(baseStr, categoryStr);
        }
    }
}
