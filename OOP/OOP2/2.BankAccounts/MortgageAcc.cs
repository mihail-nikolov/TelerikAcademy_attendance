namespace _2.BankAccounts
{
    public class MortgageAcc: Account
    {
        public MortgageAcc(double interestRate, Customer customerType)
            :base(interestRate, customerType)
        {
        }
        public override double CalculateInterestAmount()
        {
            if (this.MonthsExisting <= 12 && this.CustomerType is Company)
            {
                return base.CalculateInterestAmount() / 2;
            }
            if (this.MonthsExisting <= 6 && this.CustomerType is Individual)
            {
                return base.CalculateInterestAmount() / 2;
            }
            else
            {
                return base.CalculateInterestAmount();
            }
        }
    }
}
