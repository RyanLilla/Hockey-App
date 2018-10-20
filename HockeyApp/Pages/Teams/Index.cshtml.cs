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

        public string NameSort { get; set; }
        public string LocationSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Team> Team { get; set; }

        public async Task OnGetAsync(string sortOrder, 
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            LocationSort = sortOrder == "Location" ? "location_desc" : "Location";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Team> teamIQ = from t in _context.Team
                                      select t;

            if (!String.IsNullOrEmpty(searchString))
            {
                teamIQ = teamIQ.Where(t => t.TeamName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    teamIQ = teamIQ.OrderByDescending(t=> t.TeamName);
                    break;
                case "Location":
                    teamIQ = teamIQ.OrderBy(t => t.TeamLocation);
                    break;
                case "location_desc":
                    teamIQ = teamIQ.OrderByDescending(t => t.TeamLocation);
                    break;
                default:
                    teamIQ = teamIQ.OrderBy(t => t.TeamName);
                    break;
            }

            int pageSize = 5;
            Team = await PaginatedList<Team>.CreateAsync(
                teamIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
