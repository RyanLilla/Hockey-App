using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HockeyApp.Models;

namespace HockeyApp.Pages.Teams
{
    public class IndexModel : PageModel
    {
        private readonly HockeyApp.Models.LeagueContext _context;

        public IndexModel(HockeyApp.Models.LeagueContext context)
        {
            _context = context;
        }

        public IList<Team> Team { get;set; }

        public async Task OnGetAsync()
        {
            Team = await _context.Team.ToListAsync();
        }
    }
}
