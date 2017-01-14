using Computers.Logic.Components.Contracts;
using System.Collections.Generic;

namespace Computers.Logic.Components
{
    public class HDD : HardDrive, IHardDrive
    {
        public HDD(int capacity)
            : base()
        {
            this.capacity = capacity;
            this.data = new Dictionary<int, string>(this.Capacity);
        }
    }
}
