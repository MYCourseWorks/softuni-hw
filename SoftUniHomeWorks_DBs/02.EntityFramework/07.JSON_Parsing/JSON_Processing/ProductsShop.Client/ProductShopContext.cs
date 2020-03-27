namespace ProductsShop.Data
{
    using Models;
    using System.Data.Entity;

    public class ProductShopContext : DbContext
    {
        public ProductShopContext()
            : base("ProductShopContext")
        {
            Database.Initialize(true);
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(u => u.BoughtProducts).WithOptional(p => p.Buyer);

            modelBuilder.Entity<User>().HasMany(u => u.SoldProducts).WithRequired(p => p.Seller);

            modelBuilder.Entity<User>().HasMany(u => u.Friends).WithMany().Map(mc =>
            {
                mc.MapLeftKey("UserId");
                mc.MapRightKey("FriendId");
                mc.ToTable("UserFriends");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}