using System;
using System.Collections;
using System.Collections.Generic;

namespace HockeyApp.Models
{
    public class Coach
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HireDate { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}