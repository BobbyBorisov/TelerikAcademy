using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Bank
{
    class Bank
    {
        static void Main()
        {
            List<Account> accounts = new List<Account>(){
                new DepositAccount(Customer.Individual,2000,20),
                new LoanAccount(Customer.Company,10000,200),
                new MortgageAccount(Customer.Company,50000,2000)
            };

            foreach (Account acc in accounts)
            {
                acc.DisplayInfo();
                var result = acc.CalculateInterestAmount(2);
                Console.WriteLine("Interest amount for 2 months is {0}",result);
            }
        }
    }
}
