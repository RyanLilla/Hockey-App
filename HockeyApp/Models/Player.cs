using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HockeyApp.Models
{
    public enum Position
    {
        Center,
        LeftWing,
        RightWing,
        Defenceman,
        Goalie
    }

    public class Player
    {
        public int ID { get; set; }
        public int CoachID { get; set; }
        public int TeamID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Position? Position { get; set; }
        public DateTime DraftDate { get; set; }

        public Coach Coach { get; set; }
        public Team Team { get; set; }
    }
}
