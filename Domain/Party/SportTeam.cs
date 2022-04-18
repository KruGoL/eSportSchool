using eSportSchool.Data.Party;
using eSportSchool.Domain.Sport;

namespace eSportSchool.Domain.Party
{
    public interface ISportTeamsRepo : IRepo<SportTeam> { }
    public sealed class SportTeam : UniqueEntity<SportTeamData>
    {

        public SportTeam():this(new SportTeamData()){}
        public SportTeam(SportTeamData d) : base(d){}

        public string OwnerId => getValue(Data?.OwnerId);
        public string Title => getValue(Data?.Title);
        public string SportId => getValue(Data?.SportId);
        public string Description => getValue(Data?.Description);
        public DateTime CreatedDate => getValue(Data?.CreatedDate);
        public override string ToString() => $"{Title} : {Sport} ({CreatedDate})";

        public KindOfSport? Sport { get; set; }
        public Trainer? Trainer { get; set; }
    }
}
