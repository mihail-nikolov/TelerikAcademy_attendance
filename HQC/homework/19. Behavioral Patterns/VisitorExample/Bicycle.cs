using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    public class Bicycle : Vehicle
    {
        public override void Accept(IMaintainable maintainer)
        {
            maintainer.Maintain(this);
        }
    }
}
