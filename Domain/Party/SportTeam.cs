using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSportSchool.Data.Party;

namespace eSportSchool.Domain.Party
{
    public interface ISportTeamsRepo : IRepo<SportTeam> { }
    public sealed class SportTeam : UniqueEntity<SportTeamData>
    {

        public SportTeam():this(new SportTeamData()){}
        public SportTeam(SportTeamData d) : base(d){}

        public string Id => getValue(Data?.Id);
        public string OwnerId => getValue(Data?.OwnerId);
        public string Title => getValue(Data?.Title);
        public string Description => getValue(Data?.Description);
        public DateTime CreatedDate => getValue(Data?.CreatedDate);
        public override string ToString() => $"{Title} ({CreatedDate})";

    }
}
