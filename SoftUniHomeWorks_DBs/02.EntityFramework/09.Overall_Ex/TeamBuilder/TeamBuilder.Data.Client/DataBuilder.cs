using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq.Expressions;
using TeamBuilder.Data.Client.Extentions;

namespace TeamBuilder.Data.Client
{
    public class DataBuilder
    {
        private static DataBuilder builder;

        public static DataBuilder GetBuilder
        {
            get
            {
                return builder == null ? builder = new DataBuilder() : builder;
            }
        }

        public void BuildUser(EntityTypeConfiguration<User> userBuilder)
        {
            userBuilder
                .Property(u => u.Username)
                .IsUnique("Username");

            userBuilder
                .HasMany(u => u.Teams)
                .WithMany(t => t.Users)
                .Map(m =>
                {
                    m.ToTable("UserTeams");
                    m.MapLeftKey("TeamId");
                    m.MapRightKey("UserId");
                });
        }

        public void BuildTeam(EntityTypeConfiguration<Team> teamBuilder)
        {
            teamBuilder
                .Property(t => t.Name)
                .IsUnique("Name");

            teamBuilder
                .HasOptional(e => e.Creator)
                .WithMany(c => c.CreatedTeams)
                .HasForeignKey(e => e.CreatorId);

            teamBuilder
                .Property(t => t.Acronym)
                .HasMaxLength(3)
                .IsFixedLength();
        }

        public void BuildEvent(EntityTypeConfiguration<Event> eventBuilder)
        {
            eventBuilder
                .HasMany(e => e.Teams)
                .WithMany(t => t.Events)
                .Map(m =>
                {
                    m.ToTable("EventTeams");
                    m.MapLeftKey("TeamId");
                    m.MapRightKey("EventId");
                });

            eventBuilder
                .HasOptional(e => e.Creator)
                .WithMany(c => c.CreatedEvents)
                .HasForeignKey(e => e.CreatorId);
        }

        public void BuildInvitation(EntityTypeConfiguration<Invitation> invitationBuilder)
        {
            invitationBuilder
                .HasOptional(i => i.InvitedUser)
                .WithMany(u => u.Invitations)
                .HasForeignKey(i => i.InvitedUserId);

            invitationBuilder
                .HasOptional(i => i.Team)
                .WithMany(t => t.Invitatins)
                .HasForeignKey(i => i.TeamId);
        }
    }
}
