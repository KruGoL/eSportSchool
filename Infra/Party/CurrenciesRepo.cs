using eSportSchool.Data.Party;
using eSportSchool.Domain.Party;

namespace eSportSchool.Infra.Party
{
    public abstract class CurrenciesRepo : Repo<Currency, CurrencyData>, ICurrenciesRepo
    {
        public CurrenciesRepo(eSportSchoolDB? db) : base(db, db?.Currencies) { }
        protected override Currency toDomain(CurrencyData d) => new(d);
        internal override IQueryable<CurrencyData> addFilter(IQueryable<CurrencyData> q)
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
