using eSportSchool.Data.Party;
using eSportSchool.Domain.Party;
using eSportSchool.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eSportSchool.Tests.Infra {
    [TestClass]
    public class PagedRepoTests : AbstractClassTests<PagedRepo<KindOfSport, KindOfSportData>, OrderedRepo<KindOfSport, KindOfSportData>> {
        private class testClass : PagedRepo<KindOfSport, KindOfSportData> {
            public testClass(DbContext? c, DbSet<KindOfSportData>? s) : base(c, s) { }
            protected internal override KindOfSport toDomain(KindOfSportData d) => new(d);
        }
        protected override PagedRepo<KindOfSport, KindOfSportData> createObj() => new testClass(null, null);
    }
}

