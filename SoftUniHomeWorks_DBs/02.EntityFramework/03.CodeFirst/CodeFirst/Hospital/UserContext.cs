namespace Hospital
{
    using System.Data.Entity;
    using Models;

    public class UserContext : DbContext
    {
        public UserContext() : base("UserContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<UserContext>());
        }

        public virtual DbSet<Patient> Patients { get; set; }

        public virtual DbSet<Medication> Medications { get; set; }

        public virtual DbSet<Diagnose> Diagnoses { get; set; }
    }
}