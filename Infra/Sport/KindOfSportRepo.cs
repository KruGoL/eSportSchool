using eSportSchool.Data.Sport;
using eSportSchool.Domain.Sport;

namespace eSportSchool.Infra.Sport
{
    public class KindOfSportRepo : Repo<KindOfSport, KindOfSportData>, IKindOfSportRepo
    {
        public KindOfSportRepo(eSportSchoolDB db) : base(db, db.KindOfSports) { }
        protected override KindOfSport toDomain(KindOfSportData d) => new(d);
        internal override IQueryable<KindOfSportData> addFilter(IQueryable<KindOfSportData> q)
         {
            var y = CurrentFilter;
            if (string.IsNullOrWhiteSpace(y)) return q;
            return q.Where(
                    x => x.Id.Contains(y)
                    || x.Name.Contains(y)
                    || x.Description.Contains(y));
        }
    }
}

