using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HockeyApp.Models
{
    public class Team
    {
        public int ID { get; set; }
        public int? CoachID { get; set; }
        public int DivisionID { get; set; }
        public int ConferenceID { get; set; }

        [Display(Name = "Team")]
        public string TeamName { get; set; }

        [Display(Name = "Location")]
        public string TeamLocation { get; set; }

        public Coach Coach { get; set; }
        public Division Division { get; set; }
        public Conference Conference { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}
