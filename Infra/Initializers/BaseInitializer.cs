using Microsoft.EntityFrameworkCore;
using eSportSchool.Data;

namespace eSportSchool.Infra.Initializers
{
    public abstract class BaseInitializer<TData> where TData: EntityData{
        internal protected DbContext? db;
        internal protected DbSet<TData>? set;
        protected BaseInitializer(DbContext? c, DbSet<TData>? s) {
            db = c;
            set = s;
        }
        public void Init() {
            if (set?.Any() ?? true) return;
            set.AddRange(getEntities);
            db?.SaveChanges();
        }
        protected abstract IEnumerable<TData> getEntities { get; }
    }

    public static class eSportSchoolDBInitializer
    {
        public static void Init(eSportSchoolDB? db)
        {
            new AddressesInitializer(db).Init();
            new TrainersInitializer(db).Init();
            new SportTeamsInitializer(db).Init();
        }
    }
}
