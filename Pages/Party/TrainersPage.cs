using eSportSchool.Domain.Party;
using eSportSchool.Facade.Party;

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
            nameof(TrainerView.DoB)
        };
    }
}