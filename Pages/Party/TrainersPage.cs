using eSportSchool.Aids;
using eSportSchool.Data.Party;
using eSportSchool.Domain.Party;
using eSportSchool.Facade.Party;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eSportSchool.Pages.Party
{
    public class TrainersPage : PagedPage<TrainerView, Trainer, ITrainersRepo>
    {
        public TrainersPage(ITrainersRepo r) : base(r) { }

        protected override Trainer toObject(TrainerView? item) => new TrainerViewFactory().Create(item);

        protected override TrainerView toView(Trainer? entity) => new TrainerViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(TrainerView.Id),
            nameof(TrainerView.FullName),
            nameof(TrainerView.FirstName),
            nameof(TrainerView.LastName),
            nameof(TrainerView.Gender),
            nameof(TrainerView.DoB),
            nameof(TrainerView.Description)
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