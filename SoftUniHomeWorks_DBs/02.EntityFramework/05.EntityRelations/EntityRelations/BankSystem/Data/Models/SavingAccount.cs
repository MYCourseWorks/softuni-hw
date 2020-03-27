using System;

namespace BankSystem.Data.Models
{
    public class SavingAccount : BankAccount
    {
        private int interestRate { get; set; }

        public int InterestRate
        {
            get { return this.interestRate; }
            set
            {
                if (0 > value || value > 100)
                    throw new ArgumentException($"interestRate: {value}, must be between 0 and 100");

                this.interestRate = value;
            }
        }

        public void AddInterest()
        {
            this.Balance = this.Balance + this.interestRate * this.Balance;
        }
    }
}
