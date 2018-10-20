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
            //context.Database.EnsureCreated();

            // Look for any Teams.
            if (context.Team.Any())
            {
                return;   // DB has been seeded
            }

            var coaches = new Coach[]
            {
                new Coach{ID = 1, FirstName = "Rick", LastName = "Tocchet", HireDate = DateTime.Parse("2015-05-28")},
                new Coach{ID = 2, FirstName = "Peter", LastName = "DeBoer", HireDate = DateTime.Parse("2017-04-11")},
                new Coach{ID = 3, FirstName = "Joel", LastName = "Quenneville", HireDate = DateTime.Parse("2008-10-16")}
            };
            foreach (Coach c in coaches)
            {
                context.Coach.Add(c);
            }
            context.SaveChanges();


            var teams = new Team[]
            {
            new Team{TeamName = "Arizona Coyotes", TeamLocation = "Arizona", CoachID = 1},
            new Team{TeamName = "San Jose Sharks", TeamLocation = "California", CoachID = 2},
            new Team{TeamName = "Chicago Blackhawks", TeamLocation = "Illinois", CoachID = 3}
            };
            foreach (Team t in teams)
            {
                context.Team.Add(t);
            }
            context.SaveChanges();
            

            var players = new Player[]
            {
            new Player{TeamID = 1, CoachID = 1, FirstName = "Oliver", LastName = "Ekman-Larsson", Position = Position.Defenseman, DraftDate = DateTime.Parse("2018-10-26")},
            new Player{TeamID = 1, CoachID = 1, FirstName = "Antti", LastName = "Raanta", Position = Position.Goalie, DraftDate = DateTime.Parse("2018-12-01")},
            new Player{TeamID = 2, CoachID = 2, FirstName = "Joe", LastName = "Pavelski", Position = Position.Center, DraftDate = DateTime.Parse("2018-10-26")},
            new Player{TeamID = 2, CoachID = 2, FirstName = "Logan", LastName = "Couture", Position = Position.Center, DraftDate = DateTime.Parse("2018-12-01")},
            new Player{TeamID = 3, CoachID = 3, FirstName = "Jonathan", LastName = "Toews", Position = Position.Center, DraftDate = DateTime.Parse("2018-10-26")},
            new Player{TeamID = 3, CoachID = 3, FirstName = "Brent", LastName = "Seabrook", Position = Position.Defenseman, DraftDate = DateTime.Parse("2018-12-01")}
            };
            foreach (Player p in players)
            {
                context.Player.Add(p);
            }
            context.SaveChanges();     

        }
    }
}
