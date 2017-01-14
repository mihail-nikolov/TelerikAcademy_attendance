using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    // The 'Visitor' interface (asbtract) class
    public interface IMaintainable
    {
        void Maintain(Vehicle vehicle);
    }
}
