using eSportSchool.Data.Party;
using eSportSchool.Domain.Party;
using eSportSchool.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eSportSchool.Tests.Infra {
    [TestClass]
    public class RepoTests : AbstractClassTests<Repo<KindOfSport, KindOfSportData>, PagedRepo<KindOfSport, KindOfSportData>> {
        private class testClass : Repo<KindOfSport, KindOfSportData> {
            public testClass(DbContext? c, DbSet<KindOfSportData>? s) : base(c, s) { }

            protected override KindOfSport toDomain(KindOfSportData d) => new(d);
        }
        protected override Repo<KindOfSport, KindOfSportData> createObj() => new testClass(null, null);
    }
}

