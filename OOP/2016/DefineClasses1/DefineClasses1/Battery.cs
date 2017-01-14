using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefineClasses1
{
    public enum BatType
    {
        LiIon, NiMH, NiCd
    }
    public class Battery
    {
        public const uint MAX_HOURS_IDLE = 300;
        public const uint MAX_HOURS_TALK = 100;
        private string model;
        private uint hoursIdle;
        private uint hoursTalk;
        private BatType theType;

        public Battery(string model, uint hoursIdle, uint hoursTalk, BatType theType)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.TheType = theType;
        }
        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public uint HoursIdle
        {
            get { return this.hoursIdle; }
            set 
            {
                if (value > MAX_HOURS_IDLE)
                {
                    string message = string.Format("hours idle cannot be > {0}", MAX_HOURS_IDLE);
                    throw new ArgumentOutOfRangeException(message);
                }
                this.hoursIdle = value; 
            }
        }
        public uint HoursTalk
        {
            get { return this.hoursTalk; }
            set
            {
                if (value > MAX_HOURS_TALK)
                {
                    string message = string.Format("hours talk cannot be > {0}", MAX_HOURS_TALK);
                    throw new ArgumentOutOfRangeException(message);
                }
                this.hoursTalk = value; 
            }
        }
        public BatType TheType
        {
            get { return this.theType; }
            set { this.theType = value; }
        }
    }
}
