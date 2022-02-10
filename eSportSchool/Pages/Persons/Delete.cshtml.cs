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
    public class DeleteModel : PageModel
    {
        private readonly eSportSchool.Data.ApplicationDbContext _context;

        public DeleteModel(eSportSchool.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PersonView Person { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var d = await _context.Persons.FirstOrDefaultAsync(m => m.Id == id);
            Person = new PersonViewFactory().Create(new Person(d));
            if (Person == null)
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

            var d = await _context.Persons.FindAsync(id);

            if (Person != null)
            {
                _context.Persons.Remove(d);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
