using eSportSchool.Data.Party;

namespace eSportSchool.Domain.Party {
    public interface ISportTeamsRepo : IRepo<SportTeam> { }
    public sealed class SportTeam : NamedEntity<SportTeamData> {

        public SportTeam():this(new SportTeamData()){}
        public SportTeam(SportTeamData d) : base(d){}

        public string OwnerId => getValue(Data?.OwnerId);
        public string SportId => getValue(Data?.SportId);
        public DateTime CreatedDate => getValue(Data?.CreatedDate);
        public override string ToString() => $"{Name} : {KindOfSport?.Name} ({CreatedDate})";
        public KindOfSport? KindOfSport => GetRepo.Instance<IKindOfSportRepo>()?.Get(SportId);
        public string? SportName => KindOfSport?.Name ?? "Unknown";
    }
}
