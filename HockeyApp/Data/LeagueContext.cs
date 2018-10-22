using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HockeyApp.Models
{
    public class LeagueContext : DbContext
    {
        public LeagueContext (DbContextOptions<LeagueContext> options)
            : base(options)
        {
        }

        public DbSet<Team> Team { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<Coach> Coach { get; set; }
        public DbSet<Division> Division { get; set; }
        public DbSet<Conference> Conference { get; set; }

    }
}
