using Cosmetics.Common;
using Cosmetics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Products
{
    public class Shampoo : ProductAbstr, IShampoo
    {
        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
            : base(name, brand,price, gender)
        {
            this.Milliliters = milliliters;
            this.Usage = usage;
        }
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
        public uint Milliliters { get; protected set; }
        public UsageType Usage { get; protected set; }
        public override string Print()
        {
            string baseStr = base.Print();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(baseStr);
            sb.AppendLine(string.Format("  * Quantity: {0} ml", this.Milliliters));
            sb.AppendLine(string.Format("  * Usage: {0}", this.Usage));
            return sb.ToString().TrimEnd();
        }
    }
}
