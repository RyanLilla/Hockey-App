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
    public class DetailsModel : PageModel
    {
        private readonly HockeyApp.Models.LeagueContext _context;

        public DetailsModel(HockeyApp.Models.LeagueContext context)
        {
            _context = context;
        }

        public Team Team { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Team = await _context.Team
                .Include(t => t.Players)
                .Include(t => t.Coach)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Team == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
