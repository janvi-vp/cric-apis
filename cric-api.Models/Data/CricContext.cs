using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cric_api.Models;
using cric_api.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace cric_api.Data
{
    public class CricContext : DbContext
    {
        public CricContext(DbContextOptions<CricContext> options) : base(options) { }

        public DbSet<Player> Players { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Venue> Venues { get; set; }

        public DbSet<Match> Matches { get; set; }

        public DbSet<TeamPlayer> TeamPlayers { get; set; } // join table

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TeamPlayer>()
                .HasOne(tp => tp.Team)
                .WithMany(t => t.TeamPlayers)
                .HasForeignKey(tp => tp.TeamId)
                .OnDelete(DeleteBehavior.Cascade); // cascade when team deleted

            modelBuilder.Entity<TeamPlayer>()
                .HasOne(tp => tp.Player)
                .WithMany(p => p.TeamPlayers)
                .HasForeignKey(tp => tp.PlayerId)
                .OnDelete(DeleteBehavior.Cascade); // cascade when player deleted

            modelBuilder.Entity<Match>()
                .HasOne(m => m.Team1)
                .WithMany() // no navigation
                .HasForeignKey(m => m.Team1Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.Team2)
                .WithMany() // no navigation
                .HasForeignKey(m => m.Team2Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}