using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HockeyApp.Models
{
    public class Team
    {
        public int ID { get; set; }
        public int? CoachID { get; set; }
        public string TeamName { get; set; }
        public string TeamLocation { get; set; }

        public Coach Coach { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}
