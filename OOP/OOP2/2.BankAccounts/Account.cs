using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BankAccounts
{
    class Account: IAccount
    {
        private double balance;
        private double interestRate;
        private int monthsExisting;
        private Customer customerType;
        public double Balance
        {
            get { return this.Balance; }
            set { this.Balance = value; }
        }
        public int MonthsExisting
        {
            get { return this.monthsExisting; }
            set { this.monthsExisting = value; }
        }
        public double InterestRate
        {
            get { return this.interestRate; }
            set { this.interestRate = value; }
        }

        public Customer CustomerType
        {
            get { return this.customerType; }
            set { this.customerType = value; }
        }

        public virtual double CalculateInterestAmount(int numOfMonths)
        {
            return this.InterestRate * numOfMonths;
        }
        public virtual void Deposit(double money)
        {
            this.Balance += money;
        }
    }
}
