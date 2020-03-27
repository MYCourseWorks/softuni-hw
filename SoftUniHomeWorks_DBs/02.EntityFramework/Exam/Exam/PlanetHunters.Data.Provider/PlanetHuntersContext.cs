namespace PlanetHunters.Data.Provider
{
    using System.Data.Entity;

    public class PlanetHuntersContext : DbContext
    {
        public PlanetHuntersContext() : base("PlanetHuntersContext")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<PlanetHuntersContext>());
        }

        public virtual DbSet<Astronomer> Astronomers { get; set; }
        public virtual DbSet<Discovery> Discoveries { get; set; }
        public virtual DbSet<Planet> Planets { get; set; }
        public virtual DbSet<Star> Stars { get; set; }
        public virtual DbSet<Telescope> Telescopes { get; set; }
        public virtual DbSet<StarSystem> StarSystems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Astronomer>()
                .HasMany(a => a.ObservedDiscoveries)
                .WithMany(d => d.Observers)
                .Map(m =>
                {
                    m.ToTable("ObserverDiscovery");
                    m.MapLeftKey("AstronomerId");
                    m.MapRightKey("DiscoveryId");
                });

            modelBuilder
                .Entity<Astronomer>()
                .HasMany(a => a.PioneerDiscoveries)
                .WithMany(d => d.Pioneers)
                .Map(m =>
                {
                    m.ToTable("PioneerDiscovery");
                    m.MapLeftKey("AstronomerId");
                    m.MapRightKey("DiscoveryId");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}