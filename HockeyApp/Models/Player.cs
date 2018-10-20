using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HockeyApp.Models
{
    public enum Position
    {
        Center,
        LeftWing,
        RightWing,
        Defenseman,
        Goalie
    }

    public class Player
    {
        public int ID { get; set; }
        public int CoachID { get; set; }
        public int TeamID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get => $"{FirstName} {LastName}";
        }
        public Position? Position { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DraftDate { get; set; }

        public Coach Coach { get; set; }
        public Team Team { get; set; }
    }
}
