using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HockeyApp.Models
{
    public class Coach
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get => $"{FirstName} {LastName}";
        }
        public DateTime HireDate { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}