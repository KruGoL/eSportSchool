using eSportSchool.Data.Party;
using Microsoft.EntityFrameworkCore;

namespace eSportSchool.Infra
{
    public sealed class eSportSchoolDB: DbContext
    {
        public eSportSchoolDB(DbContextOptions<eSportSchoolDB> options) : base(options) { }
        public DbSet<TrainerData>? Trainers { get; set; }
        public DbSet<SportTeamData>? SportTeams { get; set; }
        public DbSet<AddressData>? Addresses { get; set; }

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
        }
    }
}
