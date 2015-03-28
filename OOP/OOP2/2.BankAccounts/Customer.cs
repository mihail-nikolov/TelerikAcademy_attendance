using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BankAccounts
{
    class Customer
    {
        private string name;
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public Customer(string name)
        {
            this.Name = name;
        }
    }
}
