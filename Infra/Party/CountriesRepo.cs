using eSportSchool.Data.Party;
using eSportSchool.Domain.Party;

namespace eSportSchool.Infra.Party
{
    public abstract class CountriesRepo : Repo<Country, CountryData>, ICountriesRepo
    {
        public CountriesRepo(eSportSchoolDB? db) : base(db, db?.Countries) { }
        protected override Country toDomain(CountryData d) => new(d);
        internal override IQueryable<CountryData> addFilter(IQueryable<CountryData> q)
        {
            var y = CurrentFilter;
            if (string.IsNullOrWhiteSpace(y)) return q;
            return q.Where(
                x => x.Code.Contains(y)
                || x.Description.Contains(y)
                || x.Id.Contains(y)
                || x.Name.Contains(y));
        }
    }
}
