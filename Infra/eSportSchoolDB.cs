using eSportSchool.Data.Party;
using eSportSchool.Data.Sport;
using Microsoft.EntityFrameworkCore;

namespace eSportSchool.Infra
{
    public sealed class eSportSchoolDB: DbContext
    {
        public eSportSchoolDB(DbContextOptions<eSportSchoolDB> options) : base(options) { }
        public DbSet<TrainerData>? Trainers { get; internal set; }
        public DbSet<SportTeamData>? SportTeams { get; internal set; }
        public DbSet<AddressData>? Addresses { get; internal set; }
        public DbSet<CountryData>? Countries { get; internal set; }
        public DbSet<CurrencyData>? Currencies { get; internal set; }
        public DbSet<KindOfSportData>? KindOfSports { get; internal set; }

        protected override void OnModelCreating(ModelBuilder b) {
            base.OnModelCreating(b);
            InitializeTables(b);
        }
        public static void InitializeTables(ModelBuilder b)
        {
            var s = nameof(eSportSchoolDB)[0..^2];
            _ = (b?.Entity<TrainerData>()?.ToTable(nameof(Trainers), s));
            _ = (b?.Entity<SportTeamData>()?.ToTable(nameof(SportTeams), s));
            _ = (b?.Entity<AddressData>()?.ToTable(nameof(Addresses), s));
            _ = (b?.Entity<CountryData>()?.ToTable(nameof(Countries), s));
            _ = (b?.Entity<CurrencyData>()?.ToTable(nameof(Currencies), s));
            _ = (b?.Entity<KindOfSportData>()?.ToTable(nameof(KindOfSports), s));
        }
    }
}
