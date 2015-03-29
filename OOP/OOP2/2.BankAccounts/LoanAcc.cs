namespace _2.BankAccounts
{
    public class LoanAcc: Account
    {
        public LoanAcc(double interestRate, Customer customerType)
            :base(interestRate, customerType)
        {
        }
        public override double CalculateInterestAmount()
        {
            if (this.MonthsExisting <= 2 && CustomerType is Company)
            {
                return base.CalculateInterestAmount() * 0;
            }
            if (this.MonthsExisting <= 3 && CustomerType is Individual)
            {
                return base.CalculateInterestAmount() * 0;
            }
            else
            {
                return base.CalculateInterestAmount();
            }
        }
    }
}
