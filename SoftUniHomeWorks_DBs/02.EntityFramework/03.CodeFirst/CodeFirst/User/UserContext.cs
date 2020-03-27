namespace User
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class UserContext : DbContext
    {
        public UserContext()
            : base("UserContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }
    }
}