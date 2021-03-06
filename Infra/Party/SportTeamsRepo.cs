using Microsoft.EntityFrameworkCore;
using eSportSchool.Data.Party;
using eSportSchool.Domain.Party;

namespace eSportSchool.Infra.Party
{
    public sealed class SportTeamsRepo : Repo<SportTeam, SportTeamData>, ISportTeamsRepo
    {
        public SportTeamsRepo(eSportSchoolDB? db) : base(db, db?.SportTeams) { }
        protected internal override SportTeam toDomain(SportTeamData d) => new (d);
        internal override IQueryable<SportTeamData> addFilter(IQueryable<SportTeamData> q)
        {
            var y = CurrentFilter;
            if (string.IsNullOrWhiteSpace(y)) return q;
            return q.Where(
                x => x.OwnerId.Contains(y)
                || x.Description.Contains(y)
                || x.SportId.Contains(y)
                || x.Id.Contains(y)
                || x.Name.Contains(y)
                || x.CreatedDate.ToString().Contains(y));
        }
    }
}
