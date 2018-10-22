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
                new Coach{ID = 9, FirstName = "Joel", LastName = "Quenneville", HireDate = DateTime.Parse("2008-10-16")}
            };
            foreach (Coach c in coaches)
            {
                context.Coach.Add(c);
            }
            context.SaveChanges();


            var conferences = new Conference[]
            {
                new Conference{ID = 1, ConferenceName = "Western"},
                new Conference{ID = 2, ConferenceName = "Eastern"}
            };
            foreach (Conference c in conferences)
            {
                context.Conference.Add(c);
            }
            context.SaveChanges();


            var divisions = new Division[]
            {
                new Division{ID = 1, DivisionName = "Pacific"},
                new Division{ID = 2, DivisionName = "Central"},
                new Division{ID = 3, DivisionName = "Metropolitan"},
                new Division{ID = 4, DivisionName = "Atlantic"}
            };
            foreach (Division d in divisions)
            {
                context.Division.Add(d);
            }
            context.SaveChanges();


            var teams = new Team[]
            {
                new Team{TeamName = "Arizona Coyotes", TeamLocation = "Arizona", CoachID = 1, DivisionID = 1, ConferenceID = 1},
                new Team{TeamName = "San Jose Sharks", TeamLocation = "California", CoachID = 2, DivisionID = 1, ConferenceID = 1},
                new Team{TeamName = "Anaheim Ducks", TeamLocation = "California", /*CoachID = ,*/ DivisionID = 1, ConferenceID = 1},
                new Team{TeamName = "Calgary Flames", TeamLocation = "Alberta, Canada", /*CoachID = ,*/ DivisionID = 1, ConferenceID = 1},
                new Team{TeamName = "Edmonton Oilers", TeamLocation = "Alberta, Canada", /*CoachID = ,*/ DivisionID = 1, ConferenceID = 1},
                new Team{TeamName = "Los Angeles Kings", TeamLocation = "California", /*CoachID = ,*/ DivisionID = 1, ConferenceID = 1},
                new Team{TeamName = "Vancouver Canucks", TeamLocation = "British Columbia, Canada", /*CoachID = ,*/ DivisionID = 1, ConferenceID = 1},
                new Team{TeamName = "Vegas Golden Knights", TeamLocation = "Nevada", /*CoachID = ,*/ DivisionID = 1, ConferenceID = 1},
                new Team{TeamName = "Chicago Blackhawks", TeamLocation = "Illinois", CoachID = 9, DivisionID = 2, ConferenceID = 1},
                new Team{TeamName = "Colorado Avalanche", TeamLocation = "Colorado", /*CoachID = ,*/ DivisionID = 2, ConferenceID = 1},
                new Team{TeamName = "Dallas Stars", TeamLocation = "Texas", /*CoachID = ,*/ DivisionID = 2, ConferenceID = 1},
                new Team{TeamName = "Minnesota Wild", TeamLocation = "Minnesota", /*CoachID = ,*/ DivisionID = 2, ConferenceID = 1},
                new Team{TeamName = "Nashville Predators", TeamLocation = "Tennessee", /*CoachID = ,*/ DivisionID = 2, ConferenceID = 1},
                new Team{TeamName = "St. Louis Blues", TeamLocation = "Missouri", /*CoachID = ,*/ DivisionID = 2, ConferenceID = 1},
                new Team{TeamName = "Winnipeg Jets", TeamLocation = "Manitoba, Canada", /*CoachID = ,*/ DivisionID = 2, ConferenceID = 1},                
                new Team{TeamName = "Carolina Hurricanes", TeamLocation = "North Carolina", /*CoachID = ,*/ DivisionID = 3, ConferenceID = 2},
                new Team{TeamName = "Columbus Blue Jackets", TeamLocation = "Ohio", /*CoachID = ,*/ DivisionID = 3, ConferenceID = 2},
                new Team{TeamName = "New Jersey Devils", TeamLocation = "New Jersey", /*CoachID = ,*/ DivisionID = 3, ConferenceID = 2},
                new Team{TeamName = "New York Islanders", TeamLocation = "New York", /*CoachID = ,*/ DivisionID = 3, ConferenceID = 2},
                new Team{TeamName = "New York Rangers", TeamLocation = "New York", /*CoachID = ,*/ DivisionID = 3, ConferenceID = 2},
                new Team{TeamName = "Philidelphia Flyers", TeamLocation = "Pennsylvania", /*CoachID = ,*/ DivisionID = 3, ConferenceID = 2},
                new Team{TeamName = "Pittsburgh Penguins", TeamLocation = "Pennsylvania", /*CoachID = ,*/ DivisionID = 3, ConferenceID = 2},
                new Team{TeamName = "Washington Capitals", TeamLocation = "Washington, D.C.", /*CoachID = ,*/ DivisionID = 3, ConferenceID = 2},
                new Team{TeamName = "Boston Bruins", TeamLocation = "Massachusetts", /*CoachID = ,*/ DivisionID = 4, ConferenceID = 2},
                new Team{TeamName = "Buffalo Sabres", TeamLocation = "New York", /*CoachID = ,*/ DivisionID = 4, ConferenceID = 2},
                new Team{TeamName = "Detroit Red Wings", TeamLocation = "Michigan", /*CoachID = ,*/ DivisionID = 4, ConferenceID = 2},
                new Team{TeamName = "Florida Panthers", TeamLocation = "Florida", /*CoachID = ,*/ DivisionID = 4, ConferenceID = 2},
                new Team{TeamName = "Montreal Canadiens", TeamLocation = "Quebec, Canada", /*CoachID = ,*/ DivisionID = 4, ConferenceID = 2},
                new Team{TeamName = "Ottawa Senators", TeamLocation = "Ontario, Canada", /*CoachID = ,*/ DivisionID = 4, ConferenceID = 2},
                new Team{TeamName = "Tampa Bay Lightning", TeamLocation = "Florida", /*CoachID = ,*/ DivisionID = 4, ConferenceID = 2},
                new Team{TeamName = "Toronto Maple Leafs", TeamLocation = "Ontario, Canada", /*CoachID = ,*/ DivisionID = 4, ConferenceID = 2}
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
                new Player{TeamID = 9, CoachID = 9, FirstName = "Jonathan", LastName = "Toews", Position = Position.Center, DraftDate = DateTime.Parse("2018-10-26")},
                new Player{TeamID = 9, CoachID = 9, FirstName = "Brent", LastName = "Seabrook", Position = Position.Defenseman, DraftDate = DateTime.Parse("2018-12-01")}
            };
            foreach (Player p in players)
            {
                context.Player.Add(p);
            }
            context.SaveChanges();
        }
    }
}
