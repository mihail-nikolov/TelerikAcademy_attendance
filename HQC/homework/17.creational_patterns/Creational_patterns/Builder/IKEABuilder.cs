using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.CPBuilderExample
{
    public class IKEABuilder : TableBuilder
    {

        
        public IKEABuilder()
        {
            this.Name = "IKEA";

            this.Table = new Table(MaterialType.Wooden, this.Name);
        }
        public override void BuildLegs()
        {
            this.Table.Legs = 3;
        }

        public override void BuildTabletop()
        {
            this.Table.Shape = TabletopShape.Triangle;
        }

    }
}
