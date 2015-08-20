using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public abstract class Supplement:ISupplement
    {
        private int powereffect;
        private int healtheffect;
        private int aggressioneffect;

        public Supplement(int powereffect, int healtheffect, int aggreffect)
        {
            this.PowerEffect = powereffect;
            this.HealthEffect = healtheffect;
            this.aggressioneffect = aggreffect;
        }
        public virtual int PowerEffect
        {
            get { return this.powereffect; }
            set { this.powereffect = value; }
        }

        public int HealthEffect
        {
            get { return this.healtheffect; }
            set { this.healtheffect = value; }
        }

        public virtual int AggressionEffect
        {
            get { return this.aggressioneffect; }
            set { this.aggressioneffect = value; }
        }
        public virtual void ReactTo(ISupplement otherSupplement)
        {
            
        }
    }
}
