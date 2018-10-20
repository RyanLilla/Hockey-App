using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HockeyApp.Models;
using HockeyApp.Models.TeamViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HockeyApp.Pages
{
    public class AboutModel : PageModel
    {
        private readonly LeagueContext _context;

        public AboutModel(LeagueContext context)
        {
            _context = context;
        }

        public IList<LocationGroup> Team { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<LocationGroup> data =
                from student in _context.Team
                group student by student.TeamLocation into dateGroup
                select new LocationGroup()
                {
                    LocationName = dateGroup.Key,
                    TeamCount = dateGroup.Count()
                };

            Team = await data.AsNoTracking().ToListAsync();
        }
    }
}
