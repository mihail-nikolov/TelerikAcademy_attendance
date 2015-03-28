using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BankAccounts
{
    class DepositAcc: Account
    {
        public override double CalculateInterestAmount(int numOfMonths)
        {
            if (this.Balance <= 1000 && this.Balance >= 0)
            {
                return base.CalculateInterestAmount(numOfMonths) * 0;
            }
            else
            {
                return base.CalculateInterestAmount(numOfMonths);
            }
        }
        public void WithDraw(double money)
        {
            if (money <= this.Balance)
            {
                this.Balance -= money;
            }
            else
            {
                throw new ArgumentException("not enough money!");
            }
        }
    }
}
