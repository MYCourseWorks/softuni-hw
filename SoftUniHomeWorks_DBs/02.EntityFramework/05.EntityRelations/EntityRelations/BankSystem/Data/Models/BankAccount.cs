using System;
using System.ComponentModel.DataAnnotations;

namespace BankSystem.Data.Models
{
    public abstract class BankAccount
    {
        private decimal balance;

        [Key]
        public string IBAN { get; set; }

        [Required]
        public decimal Balance
        {
            get { return this.balance; }
            set
            {
                if (0 > value)
                    throw new ArgumentException("Balance value can't be negative !");

                this.balance = value;
            }
        }

        public void DepositMoney(decimal money)
        {
            if (money < 0)
                throw new ArgumentException($"Invalid money argument: {money}");

            this.balance += money;
        }

        public void WithdrawMoney(decimal money)
        {
            if (this.balance - money < 0)
                throw new ArgumentException("Not enough money for withdraw.");

            this.balance -= money;
        }
    }
}
