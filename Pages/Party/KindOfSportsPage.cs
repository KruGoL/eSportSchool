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
    }
    
}
