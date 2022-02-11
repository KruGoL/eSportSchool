#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using eSportSchool.Data;
using eSportSchool.Data.Party;

namespace eSportSchool.Pages.SportTeams
{
    public class DeleteModel : PageModel
    {
        private readonly eSportSchool.Data.ApplicationDbContext _context;

        public DeleteModel(eSportSchool.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SportTeamData SportTeamData { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SportTeamData = await _context.SportTeamData.FirstOrDefaultAsync(m => m.Id == id);

            if (SportTeamData == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SportTeamData = await _context.SportTeamData.FindAsync(id);

            if (SportTeamData != null)
            {
                _context.SportTeamData.Remove(SportTeamData);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
