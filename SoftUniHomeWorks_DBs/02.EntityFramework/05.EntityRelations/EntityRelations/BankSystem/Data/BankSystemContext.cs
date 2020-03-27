namespace BankSystem.Data
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BankSystemContext : DbContext
    {
        public BankSystemContext()
            : base("BankSystemContext")
        {
        }

        public virtual DbSet<SavingAccount> SavingsAccount { get; set; }
        public virtual DbSet<CheckingAccount> CheckingAccounts { get; set; }
        public virtual DbSet<BankAccount> BankAccounts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserSession> UserSessions { get; set; }
    }
}