using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HockeyApp.Models
{
    public class Conference
    {
        public int ID { get; set; }
        public int DivisionID { get; set; }
        public int TeamID { get; set; }

        public ICollection<Division> Divisions { get; set; }
        public ICollection<Team> Teams { get; set; }        
    }
}
