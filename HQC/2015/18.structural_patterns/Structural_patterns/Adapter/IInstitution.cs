using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public interface IInstitution
    {
        string[] Students { get; }
        string[] Teachers { get; }
        string Name { get; }
    }
}
