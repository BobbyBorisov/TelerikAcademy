using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Bank
{
    class LoanAccount : Account
    {

        public LoanAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate) { }

        public override decimal CalculateInterestAmount(int months)
        {
            if (this.Customer == Customer.Individual)
            {
                if (months <= 3)
                {
                    return default(decimal);
                }
                else return months * this.InterestRate * this.Balance;
            }
            else {
                if (months <= 2)
                {
                    return default(decimal);
                }
                else return months * this.InterestRate * this.Balance;             
            }
                    
        }
    }
}
