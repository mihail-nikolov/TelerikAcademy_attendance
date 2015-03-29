namespace _2.BankAccounts
{
    public abstract class Account : IAccount
    {
        private double balance;
        private double interestRate;
        private int monthsExisting;
        private Customer customerType;
        public Account(double interestRate, Customer customerType)
        {
            this.Balance = 0;
            this.InterestRate = interestRate;
            this.monthsExisting = 0;
            this.CustomerType = customerType;
        }
        public double Balance
        {
            get { return this.balance; }
            protected set { this.balance = value; }
        }
        public int MonthsExisting
        {
            get { return this.monthsExisting; }
            set { this.monthsExisting = value; }
        }
        public double InterestRate
        {
            get { return this.interestRate; }
            private set { this.interestRate = value; }
        }

        public Customer CustomerType
        {
            get { return this.customerType; }
            private set { this.customerType = value; }
        }

        public virtual double CalculateInterestAmount()
        {
            return this.InterestRate * this.MonthsExisting;
        }
        public virtual void Deposit(double money)
        {
            this.Balance += money;
        }
    }
}
