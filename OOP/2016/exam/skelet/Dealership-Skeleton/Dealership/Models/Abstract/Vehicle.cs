using Dealership.Contracts;
using System.Collections.Generic;
using Dealership.Common.Enums;
using Dealership.Common;
using System.Text;

namespace Dealership.Models.Abstract
{
    public abstract class Vehicle : IVehicle
    {
        private IList<IComment> comments;
        private string make;
        private string model;
        private decimal price;
        private int wheels;

        public Vehicle(string make, string model, decimal price, int wheels)
        {
            this.Make = make;
            this.Model = model;
            this.Price = price;
            this.Wheels = wheels;
            this.comments = new List<IComment>();
        }

        public IList<IComment> Comments
        {
            // get { return new List<IComment>(this.comments); }
            get { return this.comments; }
        }

        public string Make
        {
            get
            {
                return this.make;
            }

            private set
            {
                string exceptionMessage = string.Format(
                    Constants.StringMustBeBetweenMinAndMax,
                    "Make",// could be done with nameof, but does not work in bgcoder
                    Constants.MinMakeLength,
                    Constants.MaxMakeLength);

                Validator.ValidateIntRange(
                    value.Length,
                    Constants.MinMakeLength,
                    Constants.MaxMakeLength,
                    exceptionMessage
                    );
                this.make = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                string exceptionMessage = string.Format(
                    Constants.StringMustBeBetweenMinAndMax,
                    "Model",
                    Constants.MinModelLength,
                    Constants.MaxModelLength);

                Validator.ValidateIntRange(
                    value.Length,
                    Constants.MinModelLength,
                    Constants.MaxModelLength,
                    exceptionMessage
                    );
                this.model = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            private set
            {
                string exceptionMessage = string.Format(
                   Constants.NumberMustBeBetweenMinAndMax,
                   "Price",
                   Constants.MinPrice,
                   Constants.MaxPrice);

                Validator.ValidateDecimalRange(
                    value,
                    Constants.MinPrice,
                    Constants.MaxPrice,
                    exceptionMessage
                    );
                this.price = value;
            }
        }

        public VehicleType Type { get; protected set; }

        public int Wheels
        {
            get
            {
                return this.wheels;
            }

            private set
            {
                string exceptionMessage = string.Format(
                   Constants.NumberMustBeBetweenMinAndMax,
                   "Wheels",
                   Constants.MinWheels,
                   Constants.MaxWheels);

                Validator.ValidateIntRange(
                    value,
                    Constants.MinWheels,
                    Constants.MaxWheels,
                    exceptionMessage
                    );
                this.wheels = value;
            }
        }

        // it is better to add the comment through a single method, not getting the comments list and add directly
        //public void AddComment(IComment comment)
        //{
        //    this.comments.Add(comment);
        //}

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("{0}:", this.Type.ToString()));
            sb.AppendLine(string.Format("  Make: {0}", this.Make));
            sb.AppendLine(string.Format("  Model: {0}", this.Model));
            sb.AppendLine(string.Format("  Wheels: {0}", this.Wheels));
            sb.AppendLine(string.Format("  Price: ${0}", this.Price));
            sb.AppendLine("  {0}");
            if (this.Comments.Count == 0)
            {
                sb.AppendLine("    --NO COMMENTS--");
            }
            else
            {
                sb.AppendLine("    --COMMENTS--");
                foreach (var comment in this.Comments)
                {
                    sb.AppendLine("    ----------");
                    sb.AppendLine(string.Format("    {0}", comment.Content));
                    sb.AppendLine(string.Format("      User: {0}", comment.Author));
                    sb.AppendLine("    ----------");
                }
                sb.AppendLine("    --COMMENTS--");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
