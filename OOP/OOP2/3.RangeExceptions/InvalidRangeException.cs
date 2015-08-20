using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.RangeExceptions
{
    public class InvalidRangeException<T> : ApplicationException
    {
        private T startRange;
        private T endRange;
        public InvalidRangeException(string msg, T startRange, T endRange)
            : base(msg)
        {
            this.StartRange = startRange;
            this.EndRange = endRange;
        }
        public T StartRange
        {
            get { return this.startRange; }
            set { this.startRange = value; }
        }
        public T EndRange
        {
            get { return this.endRange; }
            set { this.endRange = value; }
        }
    }
}
