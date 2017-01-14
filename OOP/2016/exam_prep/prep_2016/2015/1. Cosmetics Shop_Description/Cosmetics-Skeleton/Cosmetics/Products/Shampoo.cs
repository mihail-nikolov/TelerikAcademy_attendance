namespace Cosmetics.Products
{
    using Common;
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Shampoo : Product, IShampoo
    {
        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
            : base(name, brand, price, gender)
        {
            this.Milliliters = milliliters;
            this.Usage = usage;
        }

        public uint Milliliters { get; private set; }
        public UsageType Usage { get; private set; }

        public override decimal Price
        {
            get
            {
                return base.Price * this.Milliliters;
            }
            protected set
            {
                base.Price = value;
            }
        }

        public override string Print()
        {
            string baseStr =  base.Print();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(baseStr);
            sb.AppendLine(string.Format("  * Quantity: {0} ml", this.Milliliters));
            sb.AppendLine(string.Format("  * Usage: {0}", this.Usage));
            return sb.ToString().TrimEnd();
        }
    }
}
