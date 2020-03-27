namespace LocalStore
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class LocalStoreContext : DbContext
    {
        public LocalStoreContext()
            : base("LocalStoreContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<LocalStoreContext>());
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<StoreLocation> StoreLocations { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
    }
}