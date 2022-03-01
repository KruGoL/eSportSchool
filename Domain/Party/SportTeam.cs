using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSportSchool.Data.Party;

namespace eSportSchool.Domain.Party
{
    public class SportTeam : Entity<SportTeamData>
    {
        private const string _defaultStr = "Undefined";
        private DateTime _defaultDate => DateTime.Now;

        public SportTeam():this(new SportTeamData()){}
        public SportTeam(SportTeamData d) : base(d){}

        public string Id => Data?.Id ?? _defaultStr;
        public string OwnerId => Data?.OwnerId ?? _defaultStr;
        public string Title => Data?.Title ?? _defaultStr;
        public string Description => Data?.Description ?? "";
        public DateTime CreatedDate => Data?.CreatedDate ?? _defaultDate;
        public override string ToString() => $"{Title} ({CreatedDate})";

    }
}
