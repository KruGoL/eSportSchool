using eSportSchool.Data.Party;
using eSportSchool.Domain.Party;
using System.ComponentModel;

namespace eSportSchool.Facade.Party {
    public class KindOfSportView : UniqueView {
        [DisplayName("English name")] public string? Name { get; set; }
        [DisplayName("Description")] public string? Description { get; set; }
    }
    public sealed class KindOfSportViewFactory : BaseViewFactory<KindOfSportView, KindOfSport, KindOfSportData> {
        protected override KindOfSport toEntity(KindOfSportData d) => new(d);

    }
}
