using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTypeSystem
{
    class BitArray64 : IEnumerable<int>
    {
        private ulong value64 = 0;
        public BitArray64(ulong number = 0)
        {
            this.value64 = number;
        }
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 63; i >= 0; i--)
                yield return (int)(this.value64 >> i) & 1;
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        // Indexer declaration
        public ulong this[int index]
        {
            get
            {
                if (index >= 0 && index <= 63)
                {
                    // Check the bit at position index
                    return ((this.value64 >> index) & 1);
                }
                else
                {
                    throw new IndexOutOfRangeException(String.Format("Index {0} is invalid!", index));
                }
            }
            set
            {
                if (index < 0 || index > 63)
                {
                    throw new IndexOutOfRangeException(String.Format("Index {0} is invalid!", index));
                }
                if (value < 0 || value > 1)
                {
                    throw new ArgumentException(String.Format("Value {0} is invalid!", value));
                }
                // Clear the bit at position index
                this.value64 &= ~((ulong)(1 << index));
                // Set the bit at position index to value
                this.value64 |= (ulong)(value << index);
            }
        }
        public override bool Equals(object obj)
        {
            BitArray64 temp = obj as BitArray64;
            if (obj == null)
            {
                return false;
            }
            return Object.Equals(this.value64, temp.value64);
        }
        public static bool operator ==(BitArray64 bitValue1, BitArray64 bitValue2)
        {
            return bitValue1.Equals(bitValue2);
        }
        public static bool operator !=(BitArray64 bitValue1, BitArray64 bitValue2)
        {
            return !bitValue1.Equals(bitValue2);
        }
        public override int GetHashCode()
        {
            int hashCode = 23;
            foreach (int item in this)
            {
                hashCode += item * hashCode * 41;
            }
            return hashCode;
        }
        public override string ToString()
        {
            StringBuilder tmp = new StringBuilder();
            for (int i = 63; i >= 0; i--)
            {
                tmp.Append((this.value64 >> i) & 1);
            }
            return tmp.ToString();
        }
    }

}

