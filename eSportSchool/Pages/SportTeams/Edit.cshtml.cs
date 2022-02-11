#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eSportSchool.Data;
using eSportSchool.Data.Party;

namespace eSportSchool.Pages.SportTeams
{
    public class EditModel : PageModel
    {
        private readonly eSportSchool.Data.ApplicationDbContext _context;

        public EditModel(eSportSchool.Data.ApplicationDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SportTeamData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SportTeamDataExists(SportTeamData.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SportTeamDataExists(string id)
        {
            return _context.SportTeamData.Any(e => e.Id == id);
        }
    }
}
