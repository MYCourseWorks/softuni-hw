namespace AutoMapping
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EmployeeContext : DbContext
    {
        public EmployeeContext()
            : base("EmployeeContext")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
    }
}