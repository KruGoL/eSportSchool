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
    public class IndexModel : PageModel
    {
        private readonly eSportSchool.Data.ApplicationDbContext _context;

        public IndexModel(eSportSchool.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ExerciseData> ExerciseData { get;set; }

        public async Task OnGetAsync()
        {
            ExerciseData = await _context.ExerciseData.ToListAsync();
        }
    }
}
