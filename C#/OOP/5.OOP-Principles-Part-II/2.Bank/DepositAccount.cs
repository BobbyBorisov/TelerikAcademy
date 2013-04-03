using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Bank
{
    class DepositAccount: Account, IWithdraw
    {
        public DepositAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate) { }


        public override decimal CalculateInterestAmount(int months)
        {
            if (this.Balance > 0 && this.Balance < 1000) 
                return default(decimal);
            return months * this.InterestRate;
        }

        public void Withdraw(decimal amount)
        {
            this.Balance -= amount;
        }
    }
}
