using eSportSchool.Data.Sport;

namespace eSportSchool.Domain.Sport
{
    public interface IKindOfSportRepo : IRepo<KindOfSport> { }

    public class KindOfSport : NamedEntity<KindOfSportData>
    {
        public KindOfSport() : this(new KindOfSportData()) { }
        public KindOfSport(KindOfSportData d) : base(d) { }
    }
}
