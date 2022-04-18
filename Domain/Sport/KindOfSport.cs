using eSportSchool.Data.Sport;

namespace eSportSchool.Domain.Sport
{
    public interface IKindOfSportRepo : IRepo<KindOfSport> { }
    public sealed class KindOfSport : UniqueEntity<KindOfSportData>
    {
        public KindOfSport() : this(new KindOfSportData()) { }
        public KindOfSport(KindOfSportData d) : base(d) { }

        public string Name => getValue(Data?.Name);
        public string Description => getValue(Data?.Description);
    }
}
