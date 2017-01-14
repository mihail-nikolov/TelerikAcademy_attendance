namespace Computers.Logic.Components
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    internal class RaidArray : HardDrive, IHardDrive
    {
        private const int NoCapacity = 0;

        private List<HardDrive> hdds;

        public RaidArray(List<HardDrive> hdds) : base()
        {
            this.hdds = hdds;
            this.data = new Dictionary<int, string>(this.Capacity);
        }

        public override int Capacity
        {
            get
            {
                if (!this.hdds.Any())
                {
                    return NoCapacity;
                }

                return this.hdds.First().Capacity;
            }
        }

        public override void SaveData(int address, string newData)
        {
            foreach (var hdd in this.hdds)
            {
                hdd.SaveData(address, newData);
            }
        }

        public override string LoadData(int address)
        {
            if (!this.hdds.Any())
            {
                throw new OutOfMemoryException("No hard drive in the RAID array!");
            }

            return this.hdds.First().LoadData(address);
        }
    }
}
