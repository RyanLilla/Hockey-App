using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HockeyApp.Models;

namespace HockeyApp.Pages.Teams
{
    public class EditModel : PageModel
    {
        private readonly HockeyApp.Models.LeagueContext _context;

        public EditModel(HockeyApp.Models.LeagueContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Team Team { get; set; }

        // Called when user navigates to /Teams/Edit/<id>
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            Team = await _context.Team.FindAsync(id);

            if (Team == null)
            {
                return NotFound();
            }
            return Page();
        }

        // Called when the user submits data to the page at /Team/Edit/<id>
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Chose FindAsync over FirstOrDefaultAsync 
            // Better choice when selecting an entity from a primary key
            var teamToUpdate = await _context.Team.FindAsync(id);   

            // Attempts to update Team with the listed properties
            if (await TryUpdateModelAsync<Team>(
                teamToUpdate,
                "team",     // Prefix for form value.
                t => t.TeamName, t => t.TeamLocation))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
