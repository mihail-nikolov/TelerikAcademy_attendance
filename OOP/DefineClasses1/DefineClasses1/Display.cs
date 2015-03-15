using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefineClasses1
{
    public class Display
    {
        private byte MAX_SIZE = 8;
        private byte MIN_SIZE = 1;

        private byte size;
        private uint numberOfColors;

        public Display(byte size, uint numberOfColors)
        {
            this.Size = size;
            this.NumberOfColors = numberOfColors;
        }

        public byte Size
        {
            get { return this.size; }
            set 
            {
                if (value < MIN_SIZE || value > MAX_SIZE)
                {
                    string message = string.Format("size should be in interval [{0}, {1}]", MIN_SIZE, MAX_SIZE);
                    throw new ArgumentOutOfRangeException(message);
                }
                this.size = value; 
            }
        }
        public uint NumberOfColors
        {
            get { return this.numberOfColors; }
            set { this.numberOfColors = value; }
        }
    }
}
