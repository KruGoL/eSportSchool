using eSportSchool.Data.Party;

namespace eSportSchool.Domain.Party {
    public interface IKindOfSportRepo : IRepo<KindOfSport> { }

    public sealed class KindOfSport : NamedEntity<KindOfSportData> {
        public KindOfSport() : this(new KindOfSportData()) { }
        public KindOfSport(KindOfSportData d) : base(d) { }
        public int CompareTo(object? x) => compareTo(x as KindOfSport);
        private int compareTo(KindOfSport? c) => Name.CompareTo(c?.Name);
        public List<SportTeam> SportTeams => GetRepo.Instance<ISportTeamsRepo>()?
                    .GetAll(x => x.SportId)?
                    .Where(x => x.SportId == Id)?
                    .ToList() ?? new List<SportTeam>();
    }
}
