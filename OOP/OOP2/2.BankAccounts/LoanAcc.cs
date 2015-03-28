using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BankAccounts
{
    class LoanAcc: Account
    {
        public override double CalculateInterestAmount(int numOfMonths)
        {
            if (this.MonthsExisting < 2 && CustomerType is Company)
            {
                return base.CalculateInterestAmount(numOfMonths) * 0;
            }
            if (this.MonthsExisting < 3 && CustomerType is Individual)
            {
                return base.CalculateInterestAmount(numOfMonths) * 0;
            }
            else
            {
                return base.CalculateInterestAmount(numOfMonths);
            }
        }
    }
}
