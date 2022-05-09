using eSportSchool.Data.Party;

namespace eSportSchool.Domain.Party {
    public interface ISportTeamsRepo : IRepo<SportTeam> { }
    public sealed class SportTeam : NamedEntity<SportTeamData>
    {

        public SportTeam():this(new SportTeamData()){}
        public SportTeam(SportTeamData d) : base(d){}

        public string OwnerId => getValue(Data?.OwnerId);
        public string SportId => getValue(Data?.SportId);
        public DateTime CreatedDate => getValue(Data?.CreatedDate);
        public override string ToString() => $"{Name} : {Sport?.Name} ({CreatedDate:dd.MM.yyyy})";

        // public KindOfSport? Sport { get; set; }
        public KindOfSport? Sport => GetRepo.Instance<IKindOfSportRepo>()?
            .GetAll(x => x.Id)?
            .Where(x => x.Id == SportId).FirstOrDefault();

    }
}
