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
    public class IndexModel : PageModel
    {
        private readonly eSportSchool.Data.ApplicationDbContext _context;

        public IndexModel(eSportSchool.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<PersonView> Person { get;set; }

        public async Task OnGetAsync()
        {
            var l = await _context.Persons.ToListAsync();
            Person = new List<PersonView>();
            foreach (var personData in l)
            {
                var v = new PersonViewFactory().Create(new Person(personData));
            }
            {
                
            }
        }
    }
}
