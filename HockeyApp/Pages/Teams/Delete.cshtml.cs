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
    public class DeleteModel : PageModel
    {
        private readonly HockeyApp.Models.LeagueContext _context;

        public DeleteModel(HockeyApp.Models.LeagueContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Team Team { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Team = await _context.Team
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Team == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Delete failed. Try again";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                
            }

            var team = await _context.Team
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Team == null)
            {
                return NotFound();
            }

            try
            {
                _context.Team.Remove(team);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)

                // If Remove() fails, OnGetAsync is called with savesChangesError=true
                return RedirectToAction("./Delete",
                                     new { id, saveChangesError = true });
            }
        }
    }
}
