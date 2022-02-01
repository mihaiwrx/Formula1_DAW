using Formula1_DAW.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formula1_DAW.Context
{
    public class ContextDAW: DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamPrincipal> TeamPrincipals { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<SponsorTeam> SponsorTeams { get; set; }

        public static bool isMigration = true;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (isMigration)
                optionsBuilder.UseSqlServer(@"Server=.\;Database=F1_DAW;Trusted_connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable(name: "Country");
            });
            modelBuilder.Entity<TeamPrincipal>(entity =>
            {
                entity.ToTable(name: "TeamPrincipal");
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable(name: "User");
            });
            modelBuilder.Entity<Track>(entity =>
            {
                entity.ToTable(name: "Track");
                entity.HasOne(bc => bc.Country).WithMany().HasForeignKey(x => x.IdCountry);
            });
            // One to One -> Team - TeamPrincipal
            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable(name: "Team");
                entity.HasOne(bc => bc.TeamPrincipal).WithOne().HasForeignKey<Team>(x => x.IdTeamPrincipal);
            });
            // One to Many -> Driver - Team
            modelBuilder.Entity<Driver>(entity =>
            {
                entity.ToTable(name: "Driver");
                entity.HasOne(bc => bc.Team).WithMany().HasForeignKey(x => x.IdTeam);
            });
            modelBuilder.Entity<Sponsor>(entity =>
            {
                entity.ToTable(name: "Sponsor");
            });
            // Many to Many -> Sponsor - Team
            modelBuilder.Entity<SponsorTeam>().HasKey(sc => new { sc.IdSponsor, sc.IdTeam });
            modelBuilder.Entity<SponsorTeam>(entity =>
            {
                entity.ToTable(name: "SponsorTeam");
                entity.HasOne(bc => bc.Sponsor).WithMany().HasForeignKey(x => x.IdSponsor);
                entity.HasOne(bc => bc.Team).WithMany().HasForeignKey(x => x.IdTeam);
            });
        }

        public ContextDAW() { }

        public ContextDAW(DbContextOptions<ContextDAW> options) : base(options)
        {

        }
    }
}
