using eSportSchool.Data.Sport;
using eSportSchool.Domain.Sport;
using System.ComponentModel;

namespace eSportSchool.Facade.Sport
{
    public class KindOfSportView : UniqueView
    {
        [DisplayName("English name")] public new string? Name { get; set; }
        [DisplayName("Description")] public new string? Description { get; set; }
    }
    public sealed class KindOfSportFactory : BaseViewFactory<KindOfSportView, KindOfSport, KindOfSportData>
    {
        protected override KindOfSport toEntity(KindOfSportData d) => new(d);
    }
}
