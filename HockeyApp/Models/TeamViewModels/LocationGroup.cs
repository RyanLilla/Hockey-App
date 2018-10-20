using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HockeyApp.Models.TeamViewModels
{
    public class LocationGroup
    {
        public string LocationName { get; set; }

        public int TeamCount { get; set; }
    }
}
