namespace TeamBuilder.Data.Client
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public class TeamBuilderContext : DbContext
    {
        public TeamBuilderContext() : base("TeamBuilderContext")
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TeamBuilderContext>());
            Database.SetInitializer(new DropCreateDatabaseAlways<TeamBuilderContext>());
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Invitation> Invitations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var builder = DataBuilder.GetBuilder;
            builder.BuildUser(modelBuilder.Entity<User>());
            builder.BuildTeam(modelBuilder.Entity<Team>());
            builder.BuildEvent(modelBuilder.Entity<Event>());
            base.OnModelCreating(modelBuilder);
        }
    }
}