using eSportSchool.Data;
using eSportSchool.Domain.Party;
using eSportSchool.Facade.Party;
using eSportSchool.Facade.Party.PartyViewFactory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace eSportSchool.Pages.Trainers
{
    public class TrainersPage:PageModel
    {   // TODO To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        // TODO To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        private readonly ApplicationDbContext context; 
        [BindProperty] public TrainerView Trainer { get; set; }
        public IList<TrainerView> TrainersList { get; set; }
        public TrainersPage(ApplicationDbContext c) =>context = c;
        public IActionResult OnGetCreate() { return Page(); }
        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var d = new TrainerViewFactory().Create(Trainer).Data;
            context.TrainerData.Add(d);
            await context.SaveChangesAsync();

            return RedirectToPage("./Index" , "Index");
        }
        public async Task<IActionResult> OnGetDeleteAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var d = await context.TrainerData.FirstOrDefaultAsync(m => m.Id == id);
            Trainer = new TrainerViewFactory().Create(new Trainer(d));
            if (Trainer == null)
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

            var d = await context.TrainerData.FindAsync(id);

            if (Trainer != null)
            {
                context.TrainerData.Remove(d);
                await context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetDetailsAsync(string id)
        {
            Trainer = await GetPerson(id);
            return Trainer == null? NotFound():Page();
        }
        private async Task<TrainerView> GetPerson(string id)
        {
            if (id == null) return null;
            var d = await context.TrainerData.FirstOrDefaultAsync(m => m.Id == id);
            if (d == null) return null;
            return new TrainerViewFactory().Create(new Trainer(d));
        }
        public async Task<IActionResult> OnGetEditAsync(string id)
        {
            Trainer = await GetPerson(id);
            return Trainer == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var d = new TrainerViewFactory().Create(Trainer).Data;
            context.Attach(d).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(Trainer.Id))
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
        private bool PersonExists(string id) => context.TrainerData.Any(e => e.Id == id);
        public async Task OnGetIndexAsync()
        {
            var l = await context.TrainerData.ToListAsync();
            TrainersList = new List<TrainerView>();
            foreach (var personData in l)
            {
                var v = new TrainerViewFactory().Create(new Trainer(personData));
                TrainersList.Add(v);
            }
        }
    }
}