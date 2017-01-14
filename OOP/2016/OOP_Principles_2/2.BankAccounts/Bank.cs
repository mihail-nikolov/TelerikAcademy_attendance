using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BankAccounts
{
    public class Bank
    {
        private string name;
        private List<LoanAcc> loanAccs;
        private List<MortgageAcc> morgageAccs;
        private List<DepositAcc> depositAccs;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public List<LoanAcc> LoanAccs
        {
            get { return this.loanAccs; }
            set { this.loanAccs = value; }
        }
        public List<MortgageAcc> MortgageAccs
        {
            get { return this.morgageAccs; }
            set { this.morgageAccs = value; }
        }
        public List<DepositAcc> DepositAccs
        {
            get { return this.depositAccs; }
            set { this.depositAccs = value; }
        }

        public Bank(string name)
        {
            this.Name = name;
            this.LoanAccs = new List<LoanAcc> { };
            this.MortgageAccs = new List<MortgageAcc> { };
            this.DepositAccs = new List<DepositAcc> { };
        }
    }
}
