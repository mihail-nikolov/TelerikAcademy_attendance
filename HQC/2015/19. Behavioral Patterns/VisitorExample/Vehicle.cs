using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    //The 'Element' abstract class
    public abstract class Vehicle
    {
        public abstract void Accept(IMaintainable maintainer);
    }
}
