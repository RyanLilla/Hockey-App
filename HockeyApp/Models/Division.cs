using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HockeyApp.Models
{
    public class Division
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        //public int ConferenceID { get; set; }

        [Display(Name = "Division")]
        public string DivisionName { get; set; }

        //public Conference Conference { get; set; }

        public ICollection<Team> Teams { get; set; }

    }
}
