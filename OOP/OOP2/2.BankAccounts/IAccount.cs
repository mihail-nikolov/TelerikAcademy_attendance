using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BankAccounts
{
    interface IAccount
    {
        //void Customer;
        //void Deposit;
        //void InterestRate;
        virtual double CalculateInterestAmount(int numOfMonths);
        virtual void Deposit(double money);
    }
}
