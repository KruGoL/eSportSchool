using eSportSchool.Domain.Party;
using eSportSchool.Facade.Party;

namespace eSportSchool.Pages.Trainers
{
    public class TrainersPage: BasePage<TrainerView, Trainer, ITrainersRepo>
    {
        public TrainersPage(ITrainersRepo r) : base(r) { }

        protected override Trainer toObject(TrainerView? item) => new TrainerViewFactory().Create(item);

        protected override TrainerView toView(Trainer? entity) => new TrainerViewFactory().Create(entity);
    }
}