#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using eSportSchool.Data;
using eSportSchool.Domain.Party;
using eSportSchool.Facade;
using eSportSchool.Facade.Party;

namespace eSportSchool.Pages.Persons
{
    public class DetailsModel : PageModel
    {
        private readonly eSportSchool.Data.ApplicationDbContext _context;

        public DetailsModel(eSportSchool.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public PersonView Person { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var d = await _context.Persons.FirstOrDefaultAsync(m => m.Id == id);

            if (d == null)
            {
                return NotFound();
            }

            Person = new PersonViewFactory().Create(new Person(d));
            return Page();
        }
    }
}
