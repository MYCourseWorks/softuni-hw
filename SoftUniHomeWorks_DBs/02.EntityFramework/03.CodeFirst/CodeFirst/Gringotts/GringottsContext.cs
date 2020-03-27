namespace Gringotts
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class GringottsContext : DbContext
    {
        public GringottsContext() : base("GringottsContext")
        {
        }

        public virtual DbSet<WizzardDeposits> WizzardDeposits { get; set; }
    }
}