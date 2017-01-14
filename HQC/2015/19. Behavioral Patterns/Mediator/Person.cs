using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moderator_Pattern
{
    public abstract class Person
    {
        private readonly string name;
        

        protected Person(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return this.name; }
        }
    }
}
