using eSportSchool.Data;
using eSportSchool.Domain.Party;
using eSportSchool.Facade.Party;
using eSportSchool.Facade.Party.PartyViewFactory;
using eSportSchool.Infra.Party;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace eSportSchool.Pages.SportTeams
{
    public class SportTeamsPage :PageModel
    {
        private readonly ISportTeamsRepo repo;
        [BindProperty] public SportTeamView SportTeam { get; set; }
        public IList<SportTeamView> SportTeams { get; set; }
        public SportTeamsPage(ApplicationDbContext c) => repo = new SportTeamsRepo(c, c.SportTeamData);
        public IActionResult OnGetCreate() => Page();
        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid) return Page();
            await repo.AddAsync(new SportTeamViewFactory().Create(SportTeam));
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetDeleteAsync(string id)
        {
            SportTeam = await GetSportTeam(id);
            return SportTeam == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            if (id == null) return NotFound();
            await repo.DeleteAsync(id);
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetDetailsAsync(string id)
        {
            SportTeam = await GetSportTeam(id);
            return SportTeam == null ? NotFound() : Page();
        }
        private async Task<SportTeamView> GetSportTeam(string id) => new SportTeamViewFactory().Create(await repo.GetAsync(id));
        public async Task<IActionResult> OnGetEditAsync(string id)
        {
            SportTeam = await GetSportTeam(id);
            return SportTeam == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid) return Page();
            var obj = new SportTeamViewFactory().Create(SportTeam);
            var updated = await repo.UpdateAsync(obj);
            if (!updated) return NotFound();
            return RedirectToPage("./Index", "Index");
        
        }
        public async Task<IActionResult> OnGetIndexAsync()
        {
            var list = await repo.GetAsync();
            SportTeams = new List<SportTeamView>();
            foreach (var obj in list)
            {
                var v = new SportTeamViewFactory().Create(obj);
                SportTeams.Add(v);
            }
            return Page();
        }
    }
}
