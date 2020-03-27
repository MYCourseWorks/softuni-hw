namespace CarDealer.Data
{
    using Model;
    using System.Data.Entity;

    public class CarDealerContext : DbContext
    {
        public CarDealerContext()
            : base("CarDealerContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CarDealerContext>());
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Supplier> Supliers { get; set; }
    }
}