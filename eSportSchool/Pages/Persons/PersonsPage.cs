using eSportSchool.Data;
using eSportSchool.Domain.Party;
using eSportSchool.Facade;
using eSportSchool.Facade.Party;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace eSportSchool.Pages.Persons
{
    public class PersonsPage:PageModel
    {   // TODO To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        // TODO To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        private readonly ApplicationDbContext context; 
        [BindProperty] public PersonView Person { get; set; }
        public IList<PersonView> Persons { get; set; }
        public PersonsPage(ApplicationDbContext c) =>context = c;
        public IActionResult OnGetCreate() { return Page(); }
        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var d = new PersonViewFactory().Create(Person).Data;
            context.Persons.Add(d);
            await context.SaveChangesAsync();

            return RedirectToPage("./Index" , "Index");
        }
        public async Task<IActionResult> OnGetDeleteAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var d = await context.Persons.FirstOrDefaultAsync(m => m.Id == id);
            Person = new PersonViewFactory().Create(new Person(d));
            if (Person == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var d = await context.Persons.FindAsync(id);

            if (Person != null)
            {
                context.Persons.Remove(d);
                await context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetDetailsAsync(string id)
        {
            Person = await GetPerson(id);
            return Person == null? NotFound():Page();
        }
        private async Task<PersonView> GetPerson(string id)
        {
            if (id == null) return null;
            var d = await context.Persons.FirstOrDefaultAsync(m => m.Id == id);
            if (d == null) return null;
            return new PersonViewFactory().Create(new Person(d));
        }
        public async Task<IActionResult> OnGetEditAsync(string id)
        {
            Person = await GetPerson(id);
            return Person == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var d = new PersonViewFactory().Create(Person).Data;
            context.Attach(d).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
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

            return RedirectToPage("./Index", "Index");
        }
        private bool PersonExists(string id) => context.Persons.Any(e => e.Id == id);
        public async Task OnGetIndexAsync()
        {
            var l = await context.Persons.ToListAsync();
            Persons = new List<PersonView>();
            foreach (var personData in l)
            {
                var v = new PersonViewFactory().Create(new Person(personData));
                Persons.Add(v);
            }
        }
    }
}