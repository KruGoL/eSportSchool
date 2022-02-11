using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSportSchool.Data.Party;

namespace eSportSchool.Domain.Party
{
    public class SportTeam
    {
        private const string _defaultStr = "Undefined";
        private DateTime _defaultDate => DateTime.Now;
        private SportTeamData _data;

        public SportTeam():this(new SportTeamData()){}
        public SportTeam(SportTeamData d)=> _data = d;

        public string Id => _data?.Id ?? _defaultStr;
        public string OwnerId => _data?.OwnerId ?? _defaultStr;
        public string Title => _data?.Title ?? _defaultStr;
        public string Description => _data?.Description ?? "";
        public DateTime CreatedDate => _data?.CreatedDate ?? _defaultDate;
        public SportTeamData Data => _data;
        public override string ToString() => $"{Title} ({CreatedDate})";

    }
}
