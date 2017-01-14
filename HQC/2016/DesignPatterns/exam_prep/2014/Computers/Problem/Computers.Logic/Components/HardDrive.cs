namespace Computers.Logic.Components
{
    using System.Collections.Generic;
    using Contracts;

    public class HardDrive : IHardDrive
    {
        protected int capacity;
        protected Dictionary<int, string> data;

        public HardDrive()
        {
        }

        public virtual int Capacity
        {
            get
            {
                return this.capacity;
            }
        }

        public virtual void SaveData(int address, string newData)
        {
            this.data[address] = newData;
        }

        public virtual string LoadData(int address)
        {
            return this.data[address];
        }
    }
}
