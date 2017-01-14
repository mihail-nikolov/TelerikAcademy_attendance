using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.CPBuilderExample
{
    public abstract class TableBuilder
    {
        protected Table table;
        private string name;

        public string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                this.name = value;
            }
        }
        public Table Table
        {
            get
            {
                return this.table;
            }
            protected set
            {
                this.table = value;
            }
        }

        public abstract void BuildLegs();
        public abstract void BuildTabletop();

    }
}
