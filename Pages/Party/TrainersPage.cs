using eSportSchool.Aids;
using eSportSchool.Data.Party;
using eSportSchool.Domain.Party;
using eSportSchool.Facade.Party;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eSportSchool.Pages.Party
{
    public class TrainersPage : PagedPage<TrainerView, Trainer, ITrainersRepo>
    {
        [BindProperty]
        public IFormFile Photo { get; set; }
        IHostingEnvironment _webHostEnv;
        public TrainersPage(ITrainersRepo r, IHostingEnvironment webHostEnv) : base(r)
        {
            _webHostEnv = webHostEnv;
        }
        protected override Trainer toObject(TrainerView? item) => new TrainerViewFactory().Create(item);
        protected override TrainerView toView(Trainer? entity) => new TrainerViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(TrainerView.FullName),
            nameof(TrainerView.FirstName),
            nameof(TrainerView.LastName),
            nameof(TrainerView.SportTeamsCount),
            nameof(TrainerView.Gender),
        };
        public IEnumerable<SelectListItem> Genders
        => Enum.GetValues<IsoGender>()?
           .Select(x => new SelectListItem(x.Description(), x.ToString()))
           ?? new List<SelectListItem>();
        public string GenderDescription(IsoGender? x)
            => (x ?? IsoGender.NotApplicable).Description();
        public override object? GetValue(string name, TrainerView v)
        {
            var r = base.GetValue(name, v);
            return name == nameof(TrainerView.Gender) ? GenderDescription((IsoGender)r) : r;
        }
        public List<SportTeam?> SportTeams => toObject(Item).SportTeams;
        protected override async Task<IActionResult> postEditAsync()
        {
            if (Photo != null)
            {
                if (Item.ImgPath != null)
                {
                    string filePath = Path.Combine(_webHostEnv.WebRootPath, "img/trainers", Item.ImgPath);
                    System.IO.File.Delete(filePath);
                }
                Item.ImgPath = UploadFile();
            }

            return await base.postEditAsync();
        }
        protected override async Task<IActionResult> postCreateAsync()
        {
            if (Photo != null)
            {
                Item.ImgPath = UploadFile();
            }
            return await base.postCreateAsync();
        }
        private string UploadFile()
        {
            string uniqueFileName = null;
            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnv.WebRootPath, "img/trainers");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fs = new FileStream(filePath, FileMode.Create)) { Photo.CopyTo(fs); }
            }
            return uniqueFileName;
        }
    }
}