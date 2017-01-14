namespace _2.BankAccounts
{
    interface IAccount
    {
        //void Customer;
        //void Deposit;
        //void InterestRate;
        double CalculateInterestAmount();
        void Deposit(double money);
    }
}
