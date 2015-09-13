using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.CPBuilderExample
{
    class TableConstructor
    {
        public void Construct(TableBuilder builder)
        {
            builder.BuildLegs();
            builder.BuildTabletop();
        }
    }
}
