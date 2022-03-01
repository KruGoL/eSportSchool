using Microsoft.EntityFrameworkCore;
using eSportSchool.Data.Party;
using eSportSchool.Domain.Party;

namespace eSportSchool.Infra.Party
{
    public class SportTeamsRepo : Repo<SportTeam, SportTeamData>, ISportTeamsRepo
    {
        public SportTeamsRepo(DbContext c, DbSet<SportTeamData> s) : base(c, s) { }
        protected override SportTeam toDomain(SportTeamData d) => new SportTeam(d);
    }
}
