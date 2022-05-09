using eSportSchool.Data.Party;

namespace eSportSchool.Domain.Party {
    public interface IKindOfSportRepo : IRepo<KindOfSport> { }

    public sealed class KindOfSport : NamedEntity<KindOfSportData> {
        public KindOfSport() : this(new KindOfSportData()) { }
        public KindOfSport(KindOfSportData d) : base(d) { }
    }
}
