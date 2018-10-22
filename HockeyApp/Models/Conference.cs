using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HockeyApp.Models
{
    public class Conference
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Display(Name = "Conference")]
        public string ConferenceName { get; set; }

        //public ICollection<Division> Divisions { get; set; }
        public ICollection<Team> Teams { get; set; }        
    }
}
