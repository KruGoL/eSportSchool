using eSportSchool.Data;
using eSportSchool.Domain.Party;
using eSportSchool.Facade;
using eSportSchool.Facade.Party;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace eSportSchool.Pages.Trainings
{
    public class TrainingsPage : PageModel
    {
        private readonly ApplicationDbContext context;
        [BindProperty] public TrainingView Training { get; set; }
        public TrainingsPage(ApplicationDbContext c) => context = c;
        public IList<TrainingView> TrainingsList { get; set;}
        public IList<ExerciseView> ExercisesList { get; set; }

        public async Task OnGetIndexAsync()
        {
            var l = await context.TrainingData.ToListAsync();
            TrainingsList = new List<TrainingView>();
            foreach (var item in l)
            {
                var v = new TrainingViewFactory().Create(new Training(item));
                TrainingsList.Add(v);
            }
        }
        public IActionResult OnGetCreate() { return Page(); }
        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var d = new TrainingViewFactory().Create(Training).Data;
            context.TrainingData.Add(d);
            await context.SaveChangesAsync();

            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetDeleteAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var d= await context.TrainingData.FirstOrDefaultAsync(m => m.Id == id);
            Training = new TrainingViewFactory().Create(new Training(d));
            if (Training == null)
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

            var d = await context.TrainingData.FindAsync(id);

            if (Training != null)
            {
                context.TrainingData.Remove(d);
                await context.SaveChangesAsync();
            }

            return RedirectToPage("./Index" , "Index");
        }
        public async Task<IActionResult> OnGetDetailsAsync(string id)
        {
            Training = await GetTraining(id);
            return Training == null ? NotFound() : Page();
        }
        private async Task<TrainingView> GetTraining(string id)
        {
            if (id == null) return null;
            var d = await context.TrainingData.FirstOrDefaultAsync(m => m.Id == id);
            if (d == null) return null;
            return new TrainingViewFactory().Create(new Training(d));
        }
        public async Task<IActionResult> OnGetEditAsync(string id)
        {
            Training = await GetTraining(id);
            if (Training == null)
            {
                return NotFound();
            }
            var l = await context.ExerciseData.ToListAsync();
            ExercisesList = new List<ExerciseView>();
            foreach (var item in l)
            {
                var v = new ExerciseViewFactory().Create(new Exercise(item));
                if (v.TrainingId == Training.Id)
                {
                    v.TrainingId = Training.Id;
                    ExercisesList.Add(v);
                }
            }
            return  Page();
        }
        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var d = new TrainingViewFactory().Create(Training).Data;
            context.Attach(d).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingDataExists(Training.Id))
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
        private bool TrainingDataExists(string id) => context.TrainingData.Any(e => e.Id == id);
        
    }
}

    

    
