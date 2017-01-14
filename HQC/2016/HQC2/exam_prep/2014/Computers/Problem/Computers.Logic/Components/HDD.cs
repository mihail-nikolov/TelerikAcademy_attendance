namespace Computers.Logic.Components
{
    using System.Collections.Generic;

    internal class HDD : HardDrive
    {
        public HDD(int capacity) :
            base()
        {
            this.capacity = capacity;
            this.data = new Dictionary<int, string>(this.Capacity);
        }
    }
}
