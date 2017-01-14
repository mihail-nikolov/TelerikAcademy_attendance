using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class InfestationSpores:Supplement
    {
        private bool hasEffect;
        public InfestationSpores()
            :base(-1, 0, 20)
        {
            this.hasEffect = true;
        }
        public override int AggressionEffect
        {
            get
            {
                if (this.hasEffect)
                {
                    return base.AggressionEffect;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                base.AggressionEffect = value;
            }
        }
        public override int PowerEffect
        {
            get
            {
                if (this.hasEffect)
                {
                    return base.PowerEffect;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                base.PowerEffect = value;
            }
        }
        public override void ReactTo(ISupplement otherSupplement)
        {
            //InfestationSpores theOtherSupp = otherSupplement as InfestationSpores;
            if (otherSupplement is ISupplement)
            {
                this.hasEffect = false;
            }
        }
    }
}
