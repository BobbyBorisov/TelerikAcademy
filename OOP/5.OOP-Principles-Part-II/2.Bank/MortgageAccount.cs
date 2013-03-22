using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Bank
{
    class MortgageAccount:Account,IDeposit
    {
        public MortgageAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate) { }

        public override decimal CalculateInterestAmount(int months)
        {
            if (this.Customer == Customer.Company)
            {
                if (months <= 12) {
                    return (months * this.InterestRate);
                } 
                else return months * this.InterestRate; 
            }
            else {
                if (months <= 6) { 
                    return default(decimal); 
                }
                else return months * this.InterestRate;
            }
        }
        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }
    }
}
