using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BankAccounts
{
    class MortgageAcc: Account
    {
        public override double CalculateInterestAmount(int numOfMonths)
        {
            if (this.MonthsExisting < 12 && CustomerType is Company)
            {
                return base.CalculateInterestAmount(numOfMonths) / 2;
            }
            if (this.MonthsExisting < 6 && CustomerType is Individual)
            {
                return base.CalculateInterestAmount(numOfMonths) / 2;
            }
            else
            {
                return base.CalculateInterestAmount(numOfMonths);
            }
        }
    }
}
