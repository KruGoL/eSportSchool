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

namespace eSportSchool.Pages.Trainings.Exercises
{
    public class DeleteModel : PageModel
    {
        private readonly eSportSchool.Data.ApplicationDbContext _context;

        public DeleteModel(eSportSchool.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ExerciseData ExerciseData { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ExerciseData = await _context.ExerciseData.FirstOrDefaultAsync(m => m.Id == id);

            if (ExerciseData == null)
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

            ExerciseData = await _context.ExerciseData.FindAsync(id);

            if (ExerciseData != null)
            {
                _context.ExerciseData.Remove(ExerciseData);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
