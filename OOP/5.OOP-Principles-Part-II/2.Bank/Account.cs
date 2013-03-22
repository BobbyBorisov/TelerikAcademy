using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Bank
{
    abstract class Account
    {
        public Customer Customer { get; set; }
        public decimal Balance { get; set; }
        public decimal InterestRate { get; set; }

        public Account(Customer customer, decimal balance, decimal interestRate) {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public virtual decimal CalculateInterestAmount(int months){
            return months * this.InterestRate;
        }

        public virtual void DisplayInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine("Customer:" + this.Customer);
            sb.AppendLine("Balance:" + this.Balance);
            sb.AppendLine("InterestRate" + this.InterestRate);
            sb.AppendLine();
            Console.WriteLine(sb.ToString());
        }
    }
}
