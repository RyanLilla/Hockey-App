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

        public DbSet<HockeyApp.Models.Team> Team { get; set; }
    }
}
