using Microsoft.EntityFrameworkCore;
using eSportSchool.Data;
using eSportSchool.Infra.Initializers.Sport;

namespace eSportSchool.Infra.Initializers
{
    public abstract class BaseInitializer<TData> where TData : UniqueData
    {
        internal protected DbContext? db;
        internal protected DbSet<TData>? set;
        protected BaseInitializer(DbContext? c, DbSet<TData>? s)
        {
            db = c;
            set = s;
        }
        public void Init()
        {
            if (set?.Any() ?? true) return;
            set.AddRange(getEntities);
            db?.SaveChanges();
        }
        protected abstract IEnumerable<TData> getEntities { get; }
        internal static bool isCorrectIsoCode(string id) => string.IsNullOrWhiteSpace(id) ? false : char.IsLetter(id[0]);
    }

    public static class eSportSchoolDBInitializer
    {
        public static void Init(eSportSchoolDB? db)
        {
            new AddressesInitializer(db).Init();
            new TrainersInitializer(db).Init();
            new SportTeamsInitializer(db).Init();
            new CountriesInitializer(db).Init();
            new CurrenciesInitializer(db).Init();
            new KindOfSportInitializer(db).Init();
        }
    }
}
