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

namespace eSportSchool.Pages.Trainings
{
    public class DetailsModel : PageModel
    {
        private readonly eSportSchool.Data.ApplicationDbContext _context;

        public DetailsModel(eSportSchool.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public TrainingData TrainingData { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TrainingData = await _context.TrainingData.FirstOrDefaultAsync(m => m.Id == id);

            if (TrainingData == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
