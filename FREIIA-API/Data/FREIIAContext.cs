﻿using FREIIA_API.Models;
using Microsoft.EntityFrameworkCore;

namespace FREIIA_API.Data
{
    public class FREIIAContext : DbContext
    {
        public DbSet<Chart> Charts { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Expertise> Expertises { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ParticipantContactInfo> ParticipantContactInfos { get; set; }
        public DbSet<Connection> Connections { get; set; }
        public DbSet<ConnectionStyle> ConnectionStyles { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<LineStyle> LineStyles { get; set; }

        //public DbSet<ExpertiseParticipant> ExpertiseParticipants { get; set; }
        public FREIIAContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Create shared primarykey in expertiseparticipant table.
            modelBuilder.Entity<ExpertiseParticipant>()
            .HasKey(ep => new { ep.ExpertiseId, ep.ParticipantId });

            //Define foreign key constraints for expertiseparticipant table.
            modelBuilder.Entity<ExpertiseParticipant>()
                .HasOne(ep => ep.Expertise)
                .WithMany(e => e.ExpertiseParticipants)
                .HasForeignKey(ep => ep.ExpertiseId)
                .OnDelete(DeleteBehavior.Cascade); // added Cascade

            modelBuilder.Entity<ExpertiseParticipant>()
                .HasOne(ep => ep.Participant)
                .WithMany(p => p.ExpertiseParticipants)
                .HasForeignKey(ep => ep.ParticipantId)
                .OnDelete(DeleteBehavior.NoAction); // Should also be cascade but threw error in migration when i tried this.

            modelBuilder.Entity<Zone>()
             .HasMany(z => z.ConnectionsAsFirstZone)
             .WithOne(c => c.FirstZone)
             .HasForeignKey(c => c.FirstZoneId);

            modelBuilder.Entity<Zone>()
                .HasMany(z => z.ConnectionsAsSecondZone)
                .WithOne(c => c.SecondZone)
                .HasForeignKey(c => c.SecondZoneId)
                .IsRequired(false);

            modelBuilder.Entity<Group>()
                .HasMany(g => g.ConnectionsAsFirstGroup)
                .WithOne(c => c.FirstGroup)
                .HasForeignKey(c => c.FirstGroupId)
                .IsRequired(false);

            modelBuilder.Entity<Group>()
                .HasMany(g => g.ConnectionsAsSecondGroup)
                .WithOne(c => c.SecondGroup)
                .HasForeignKey(c => c.SecondGroupId)
                .IsRequired(false);


            modelBuilder.Entity<Participant>()
                .HasMany(p => p.ConnectionsAsFirstParticipant)
                .WithOne(c => c.FirstParticipant)
                .HasForeignKey(c => c.FirstParticipantId)
                .IsRequired(false);


            modelBuilder.Entity<Participant>()
                .HasMany(p => p.ConnectionsAsSecondParticipant)
                .WithOne(c => c.SecondParticipant)
                .HasForeignKey(c => c.SecondParticipantId)
                .IsRequired(false);


            base.OnModelCreating(modelBuilder);
        }


        public DbSet<FREIIA_API.Models.ExpertiseParticipant>? ExpertiseParticipant { get; set; }
    }
}
