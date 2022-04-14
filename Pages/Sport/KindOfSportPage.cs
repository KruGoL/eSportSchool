using eSportSchool.Domain.Sport;
using eSportSchool.Facade.Sport;

namespace eSportSchool.Pages.Sport
{
    public class KindOfSportPage : PagedPage<KindOfSportView, KindOfSport, IKindOfSportRepo>
    {
        public KindOfSportPage(IKindOfSportRepo r) : base(r) { }

        protected override KindOfSport toObject(KindOfSportView? item) => new KindOfSportViewFactory().Create(item);

        protected override KindOfSportView toView(KindOfSport? entity) => new KindOfSportViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(KindOfSportView.Id),
            nameof(KindOfSportView.Name),
            nameof(KindOfSportView.Description),
        };
    }
    
}
