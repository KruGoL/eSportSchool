using eSportSchool.Data.Party;
using eSportSchool.Domain.Party;
using System.ComponentModel;

namespace eSportSchool.Facade.Party {
    public sealed class KindOfSportView : NamedView {
    }
    public sealed class KindOfSportViewFactory : BaseViewFactory<KindOfSportView, KindOfSport, KindOfSportData> {
        protected override KindOfSport toEntity(KindOfSportData d) => new(d);

    }
}
