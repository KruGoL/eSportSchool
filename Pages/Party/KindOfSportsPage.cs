using eSportSchool.Domain;
using eSportSchool.Domain.Party;
using eSportSchool.Facade.Party;

namespace eSportSchool.Pages.Party {
    public class KindOfSportsPage : PagedPage<KindOfSportView, KindOfSport, IKindOfSportRepo>
    {
        public KindOfSportsPage(IKindOfSportRepo r) : base(r) { }

        protected override KindOfSport toObject(KindOfSportView? item) => new KindOfSportViewFactory().Create(item);

        protected override KindOfSportView toView(KindOfSport? entity) => new KindOfSportViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(KindOfSportView.Name),
            nameof(KindOfSportView.Description),
        };
        public List<SportTeam?> SportTeams => toObject(Item).SportTeams;
        public static List<Trainer>? Trainers => GetRepo.Instance<ITrainersRepo>()?.Get().ToList();
        public static string TrainerName(object? trainerId = null) {
            string? trId = trainerId?.ToString();
            foreach (Trainer? trainer in Trainers)
                if (trainer?.Id == trId) return trainer?.FullName ?? "Unspecified";
            return "Unspecified";
        }
    }
    
}
