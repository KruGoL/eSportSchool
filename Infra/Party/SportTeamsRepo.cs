using Microsoft.EntityFrameworkCore;
using eSportSchool.Data.Party;
using eSportSchool.Domain.Party;

namespace eSportSchool.Infra.Party
{
    public class SportTeamsRepo : Repo<SportTeam, SportTeamData>, ISportTeamsRepo
    {
        public SportTeamsRepo(eSportSchoolDB? db) : base(db, db?.SportTeams) { }
        protected override SportTeam toDomain(SportTeamData d) => new (d);
    }
}
