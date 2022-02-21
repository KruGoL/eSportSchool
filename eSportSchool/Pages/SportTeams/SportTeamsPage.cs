using eSportSchool.Data;
using eSportSchool.Domain.Party;
using eSportSchool.Facade.Party;
using eSportSchool.Facade.Party.PartyViewFactory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace eSportSchool.Pages.SportTeams
{
    public class SportTeamsPage :PageModel
    {
        // TODO To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        // TODO To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        private readonly ApplicationDbContext context;
        [BindProperty] public SportTeamView SportTeam { get; set; }
        public IList<SportTeamView> SportTeams { get; set; }
        public SportTeamsPage(ApplicationDbContext c) => context = c;
        public IActionResult OnGetCreate() { return Page(); }
        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var d = new SportTeamViewFactory().Create(SportTeam).Data;
            context.SportTeamData.Add(d);
            await context.SaveChangesAsync();

            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetDeleteAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var d = await context.SportTeamData.FirstOrDefaultAsync(m => m.Id == id);
            SportTeam = new SportTeamViewFactory().Create(new SportTeam(d));
            if (SportTeam == null)
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

            var d = await context.SportTeamData.FindAsync(id);

            if (SportTeam != null)
            {
                context.SportTeamData.Remove(d);
                await context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetDetailsAsync(string id)
        {
            SportTeam = await GetSportTeam(id);
            return SportTeam == null ? NotFound() : Page();
        }
        private async Task<SportTeamView> GetSportTeam(string id)
        {
            if (id == null) return null;
            var d = await context.SportTeamData.FirstOrDefaultAsync(m => m.Id == id);
            if (d == null) return null;
            return new SportTeamViewFactory().Create(new SportTeam(d));
        }
        public async Task<IActionResult> OnGetEditAsync(string id)
        {
            SportTeam = await GetSportTeam(id);
            return SportTeam == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var d = new SportTeamViewFactory().Create(SportTeam).Data;
            context.Attach(d).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SportTeamExists(SportTeam.Id))
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
        private bool SportTeamExists(string id) => context.SportTeamData.Any(e => e.Id == id);
        public async Task OnGetIndexAsync()
        {
            var l = await context.SportTeamData.ToListAsync();
            SportTeams = new List<SportTeamView>();
            foreach (var item in l)
            {
                var v = new SportTeamViewFactory().Create(new SportTeam(item));
                SportTeams.Add(v);
            }
        }
    }
}
