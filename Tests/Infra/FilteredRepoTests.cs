using eSportSchool.Aids;
using eSportSchool.Data.Party;
using eSportSchool.Domain;
using eSportSchool.Domain.Party;
using eSportSchool.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eSportSchool.Tests.Infra {
    [TestClass] public class FilteredRepoTests : AbstractClassTests<FilteredRepo<SportTeam, SportTeamData>, CrudRepo<SportTeam, SportTeamData>> {
        private class testClass : FilteredRepo<SportTeam, SportTeamData> {
            public testClass(DbContext? c, DbSet<SportTeamData>? s) : base(c, s) { }
            protected internal override SportTeam toDomain(SportTeamData d) => new(d);
        }
        protected override FilteredRepo<SportTeam, SportTeamData> createObj() {
            var db = GetRepo.Instance<eSportSchoolDB>();
            var set = db?.SportTeams;
            return new testClass(db, set);
        }
        [TestMethod] public void CurrentFilterTest() => isProperty<string>();
        [DataRow(true)]
        [DataRow(false)]
        [TestMethod]
        public void CreateSqlTest(bool hasCurrentFilter) {
            obj.CurrentFilter = hasCurrentFilter ? GetRandom.String() : null;
            var q1 = obj.createSql();
            var q2 = obj.addFilter(q1);
            areEqual(q1, q2);
            var s = q1.Expression.ToString();
            isTrue(s.EndsWith(".Select(s => s)"));
        }
    }
}

