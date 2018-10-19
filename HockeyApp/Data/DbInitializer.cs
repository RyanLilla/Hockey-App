using HockeyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HockeyApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(LeagueContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Teams.
            if (context.Team.Any())
            {
                return;   // DB has been seeded
            }

            var coaches = new Coach[]
            {
                new Coach{ID = 1, FirstName = "Rick", LastName = "Tocchet", HireDate = DateTime.Parse("1992-04-11")}
            };
            foreach (Coach c in coaches)
            {
                context.Coach.Add(c);
            }
            context.SaveChanges();


            var teams = new Team[]
            {
            new Team{TeamName = "Arizona Coyotes", TeamLocation = "Arizona", CoachID = 1},
            new Team{TeamName = "San Jose Sharks", TeamLocation = "California"},
            new Team{TeamName = "Anaheim Ducks", TeamLocation = "California"}
            };
            foreach (Team t in teams)
            {
                context.Team.Add(t);
            }
            context.SaveChanges();
            

            var players = new Player[]
            {
            new Player{TeamID = 1, CoachID = 1, FirstName = "Oliver", LastName = "Ekman-Larsson", Position = Position.Defenseman, DraftDate = DateTime.Parse("2018-10-26")},
            new Player{TeamID = 1, CoachID = 1, FirstName = "Antti", LastName = "Raanta", Position = Position.Goalie, DraftDate = DateTime.Parse("2018-12-01")}
            };
            foreach (Player p in players)
            {
                context.Player.Add(p);
            }
            context.SaveChanges();     

        }
    }
}
