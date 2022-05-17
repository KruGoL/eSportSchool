using eSportSchool.Aids;
using eSportSchool.Data.Party;
using eSportSchool.Domain.Party;
using eSportSchool.Facade.Party;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eSportSchool.Pages.Party
{
    public class TrainersPage : UploadPage<TrainerView, Trainer, ITrainersRepo>
    {
        public TrainersPage(ITrainersRepo r, IHostingEnvironment webHostEnv ) :base(r, webHostEnv)
        {
            _item = "ImgPath";
            _folderPath = "img/trainers";
            _defaultFileName = "default.jpg";
        }

        protected override Trainer toObject(TrainerView? item) => new TrainerViewFactory().Create(item);
        protected override TrainerView toView(Trainer? entity) => new TrainerViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(TrainerView.ImgPath),
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
    }
}