using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    // The 'Concrete Element' class
    public class Car : Vehicle
    {
        private string model;
        private string tires;
        private string filters;

        public Car(string model)
        {
            this.Model = model;
        }
        public Car(string model, string tires, string filters)
            :this(model)
        {
            this.Model = model;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                this.model = value;
            }
        }

        public string Tires
        {
            get
            {
                return this.tires;
            }
            private set
            {
                this.tires = value;
            }
        }

        public string Filters
        {
            get
            {
                return this.filters;
            }
            private set
            {
                this.filters = value;
            }
        }

        public override void Accept(IMaintainable maintainer)
        {
            maintainer.Maintain(this);
        }
    }
}
