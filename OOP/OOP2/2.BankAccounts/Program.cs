using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 2. Bank accounts

    A bank holds different types of accounts for its customers: deposit accounts, loan accounts and mortgage accounts. Customers could be individuals or companies.
    All accounts have customer, balance and interest rate (monthly based).
        Deposit accounts are allowed to deposit and with draw money.
        Loan and mortgage accounts can only deposit money.
    All accounts can calculate their interest amount for a given period (in months). In the common case its is calculated as follows: number_of_months * interest_rate.
    Loan accounts have no interest for the first 3 months if are held by individuals and for the first 2 months if are held by a company.
    Deposit accounts have no interest if their balance is positive and less than 1000.
    Mortgage accounts have ½ interest for the first 12 months for companies and no interest for the first 6 months for individuals.
    Your task is to write a program to model the bank system by classes and interfaces.
    You should identify the classes, interfaces, base classes and abstract actions and implement the calculation of the interest functionality through overridden methods.
*/
namespace _2.BankAccounts
{
    class Program
    {
        static void Main()
        {
            Bank bank1 = new Bank("bank1");
            Individual peshkata = new Individual("Pesho");
            Individual goshkata = new Individual("Georgi");
            Company company1 = new Company("company1");
            Company company2 = new Company("company2");

            DepositAcc peshkataDepAcc = new DepositAcc(3.2, peshkata);
            peshkataDepAcc.Deposit(500);
            Console.WriteLine("pesho Acc -->" + peshkataDepAcc.CustomerType.Name);
            Console.WriteLine("pesho balance -->" + peshkataDepAcc.Balance);
            Console.WriteLine("pesho iterestRate -->" + peshkataDepAcc.CalculateInterestAmount());
            peshkataDepAcc.Deposit(700);
            Console.WriteLine("pesho balance -->" + peshkataDepAcc.Balance);
            Console.WriteLine("pesho iterestRate -->" + peshkataDepAcc.CalculateInterestAmount());
            peshkataDepAcc.WithDraw(1000);
            Console.WriteLine("pesho balance -->" + peshkataDepAcc.Balance);
            //peshkataDepAcc.WithDraw(1000);
            Console.WriteLine("-----------------------------------------");

            DepositAcc company1DepAcc = new DepositAcc(3.2, company1);
            company1DepAcc.Deposit(50000);
            Console.WriteLine("company1 Acc -->" + company1DepAcc.CustomerType.Name);
            Console.WriteLine("company1 balance -->" + company1DepAcc.Balance);
            Console.WriteLine("company1 iterestRate -->" + company1DepAcc.CalculateInterestAmount());
            Console.WriteLine("-----------------------------------------");

            MortgageAcc goshkataMorAcc = new MortgageAcc(3, goshkata);
            peshkataDepAcc.Deposit(800);

            MortgageAcc company1MorAcc = new MortgageAcc(3.2, company1);
            company1DepAcc.Deposit(50000);

            LoanAcc goshkataLoAcc = new LoanAcc(3, goshkata);
            peshkataDepAcc.Deposit(800);

            LoanAcc company2LoAcc = new LoanAcc(3.2, company2);
            company1DepAcc.Deposit(50000);

            bank1.DepositAccs.Add(peshkataDepAcc);
            bank1.DepositAccs.Add(company1DepAcc);

            foreach (var depAcc in bank1.DepositAccs)
            {
                Console.WriteLine(depAcc.CustomerType.Name + " -- >" + depAcc.Balance);
            }
            Console.WriteLine("-----------------------------------------");

            bank1.LoanAccs.Add(goshkataLoAcc);
            bank1.LoanAccs.Add(company2LoAcc);

            for (int i = 1; i <= 7; i++)
            {
                foreach (var loAcc in bank1.LoanAccs)
                {
                    loAcc.Deposit(i  * 100);
                    Console.WriteLine("{0} balance --> {1}", loAcc.CustomerType.Name, loAcc.Balance);
                    loAcc.MonthsExisting += 1;
                    Console.WriteLine("month: {0}", i);
                    Console.WriteLine("{0} interestAmount --> {1}", loAcc.CustomerType.Name, loAcc.CalculateInterestAmount());
                }

            }
            Console.WriteLine("-----------------------------------------");

            bank1.MortgageAccs.Add(goshkataMorAcc);
            bank1.MortgageAccs.Add(company1MorAcc);

            for (int i = 1; i <= 14; i++)
            {
                foreach (var morAcc in bank1.MortgageAccs)
                {
                    morAcc.Deposit(i * 100);
                    Console.WriteLine("{0} balance --> {1}", morAcc.CustomerType.Name, morAcc.Balance);
                    morAcc.MonthsExisting += 1;
                    Console.WriteLine("month: {0}", i);
                    Console.WriteLine("{0} interestAmount --> {1}", morAcc.CustomerType.Name, morAcc.CalculateInterestAmount());
                }

            }
        }
    }
}
