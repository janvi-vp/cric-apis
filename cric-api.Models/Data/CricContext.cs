using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cric_api.Models;
using Microsoft.EntityFrameworkCore;

namespace cric_api.Data
{
    public class CricContext : DbContext
    {
        public CricContext(DbContextOptions<CricContext> options) : base(options) { }

        public DbSet<Player> Players { get; set; }

        public DbSet<Team> Teams { get; set; }
    }
}