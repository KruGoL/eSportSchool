using eSportSchool.Data;
using eSportSchool.Domain.Party;
using eSportSchool.Facade.Party;
using eSportSchool.Facade.Party.PartyViewFactory;
using eSportSchool.Infra.Party;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace eSportSchool.Pages.Trainers
{
    public class TrainersPage:PageModel
    {
        private readonly ITrainersRepo repo;
        [BindProperty] public TrainerView Trainer { get; set; }
        public IList<TrainerView> TrainersList { get; set; }
        public TrainersPage(ApplicationDbContext c) => repo = new TrainersRepo(c, c.TrainerData);
        public IActionResult OnGetCreate() => Page();
        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid) return Page();
            await repo.AddAsync(new TrainerViewFactory().Create(Trainer));
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetDeleteAsync(string id)
        {
            Trainer = await GetPerson(id);
            return Trainer == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            if (id == null) return NotFound();
            await repo.DeleteAsync(id);
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetDetailsAsync(string id)
        {
            Trainer = await GetPerson(id);
            return Trainer == null? NotFound():Page();
        }
        private async Task<TrainerView> GetPerson(string id) => new TrainerViewFactory().Create(await repo.GetAsync(id));
        public async Task<IActionResult> OnGetEditAsync(string id)
        {
            Trainer = await GetPerson(id);
            return Trainer == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid) return Page();
            var obj = new TrainerViewFactory().Create(Trainer);
            var updated = await repo.UpdateAsync(obj);
            if (!updated) return NotFound();
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetIndexAsync()
        {
            var list = await repo.GetAsync();
            TrainersList = new List<TrainerView>();
            foreach (var obj in list)
            {
                var v = new TrainerViewFactory().Create(obj);
                TrainersList.Add(v);
            }
            return Page();
        }
    }
}