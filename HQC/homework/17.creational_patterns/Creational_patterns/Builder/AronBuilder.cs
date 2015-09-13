using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.CPBuilderExample
{
    public class AronBuilder : TableBuilder    
    {
       
        public AronBuilder()
        {
            this.Name = "Aron";

            this.Table = new Table(MaterialType.Glass, this.Name);
        }
        public override void BuildLegs()
        {
            this.Table.Legs = 1;
        }

        public override void BuildTabletop()
        {
            this.Table.Shape = TabletopShape.Oval;
        }

    }
}
