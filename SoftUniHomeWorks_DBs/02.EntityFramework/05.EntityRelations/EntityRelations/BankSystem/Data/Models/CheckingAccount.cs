using System;

namespace BankSystem.Data.Models
{
    public class CheckingAccount : BankAccount
    {
        private decimal fee { get; set; }

        public decimal Fee
        {
            get { return this.fee; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Fee can't be a negative value.");

                this.fee = value;
            }
        }

        public void DeductFee()
        {
            if (this.Balance - this.Fee < 0)
                throw new ArgumentException("Not enough money to deduct fee!");

            this.Balance = this.Balance - this.fee;
        }
    }
}
