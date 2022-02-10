﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eSportSchool.Data;
using eSportSchool.Domain.Party;
using eSportSchool.Facade;
using eSportSchool.Facade.Party;

namespace eSportSchool.Pages.Persons
{
    public class EditModel : PageModel
    {
        private readonly eSportSchool.Data.ApplicationDbContext _context;

        public EditModel(eSportSchool.Data.ApplicationDbContext context)
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

            if (Person == null)
            {
                return NotFound();
            }

            Person = new PersonViewFactory().Create(new Person(d));
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

            _context.Attach(Person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(Person.Id))
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

        private bool PersonExists(string id)
        {
            return _context.Persons.Any(e => e.Id == id);
        }
    }
}
