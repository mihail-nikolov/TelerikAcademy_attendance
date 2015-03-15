using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefineClasses1
{
    public class Call
    {
        private const ushort MIN_DURATION = 0;//minutes
        private const ushort MAX_DURATION = 60;//minutes
        private DateTime dateTimeCall;
        private ulong dialedNum;
        private ulong duration;

        public Call(DateTime dateTime, ulong dialedNum, ulong duration)
        {
            this.DateTimeCall = dateTime;
            this.DialedNum = dialedNum;
            this.Duration = duration;
        }
        public DateTime DateTimeCall
        {
            get { return this.dateTimeCall; }
            set { this.dateTimeCall = value; }
        }
        public ulong DialedNum
        {
            get { return this.dialedNum; }
            set {this.dialedNum = value; }
        }
        public ulong Duration
        {
            get { return this.duration; }
            set 
            {
                if (value > MAX_DURATION || value <= 0)
                {
                    string message = string.Format("duration must be in interval [{0}, {1}]", MIN_DURATION, MAX_DURATION);
                    throw new ArgumentOutOfRangeException(message);
                }
                this.duration = value;
            }
        }
    }
}
