﻿using eSportSchool.Data.Party;
using eSportSchool.Domain.Party;

namespace eSportSchool.Infra.Party {
    public class KindOfSportRepo : Repo<KindOfSport, KindOfSportData>, IKindOfSportRepo {
        public KindOfSportRepo(eSportSchoolDB? db) : base(db, db?.KindOfSports) { }
        protected override KindOfSport toDomain(KindOfSportData d) => new(d);
        internal override IQueryable<KindOfSportData> addFilter(IQueryable<KindOfSportData> q) {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y)               
                ? q
                : q.Where(
                    x => x.Id.Contains(y)
                    || x.Name.Contains(y)
                    || x.Description.Contains(y));
        }
    }
}
