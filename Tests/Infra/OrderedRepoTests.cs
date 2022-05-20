using eSportSchool.Aids;
using eSportSchool.Data.Party;
using eSportSchool.Domain;
using eSportSchool.Domain.Party;
using eSportSchool.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eSportSchool.Tests.Infra {
    [TestClass]
    public class OrderedRepoTests : AbstractClassTests<OrderedRepo<SportTeam, SportTeamData>, FilteredRepo<SportTeam, SportTeamData>> {
        private class testClass : OrderedRepo<SportTeam, SportTeamData> {
            public testClass(DbContext? c, DbSet<SportTeamData>? s) : base(c, s) { }
            protected internal override SportTeam toDomain(SportTeamData d) => new(d);
        }
        protected override OrderedRepo<SportTeam, SportTeamData> createObj() {
            var db = GetRepo.Instance<eSportSchoolDB>();
            var set = db?.SportTeams;
            return new testClass(db, set);
        }
        [TestMethod] public void CurrentOrderTest() => isProperty<string?>();
        [TestMethod] public void DescendingStringTest() => areEqual("_desc", testClass.DescendingString);
        [DataRow(null, true)]
        [DataRow(null, false)]
        [DataRow(nameof(SportTeam.Id), true)]
        [DataRow(nameof(SportTeam.Id), false)]
        [DataRow(nameof(SportTeam.Name), true)]
        [DataRow(nameof(SportTeam.Name), false)]
        [DataRow(nameof(SportTeam.Description), true)]
        [DataRow(nameof(SportTeam.Description), false)]
        [DataRow(nameof(SportTeam.OwnerId), true)]
        [DataRow(nameof(SportTeam.OwnerId), false)]
        [DataRow(nameof(SportTeam.SportId), true)]
        [DataRow(nameof(SportTeam.SportId), false)]
        [TestMethod]
        public void CreateSqlTest(string s, bool isDescending) {
            obj.CurrentOrder = (s is null) ? s : isDescending ? s + testClass.DescendingString : s;
            var q = obj.createSql();
            var actual = q.Expression.ToString();
            if (s is null) isTrue(actual.EndsWith(".Select(s => s)"));
            else if (isDescending) isTrue(actual.EndsWith(
                $".Select(s => s).OrderByDescending(x => Convert(x.{s}, Object))"));
            else isTrue(actual.EndsWith(
                $".Select(s => s).OrderBy(x => Convert(x.{s}, Object))"));
        }

        [DataRow(true, true)]
        [DataRow(false, true)]
        [DataRow(true, false)]
        [DataRow(false, false)]
        [TestMethod]
        public void SortOrderTest(bool isDescending, bool isSame) {
            var s = GetRandom.String();
            var c = isSame ? s : GetRandom.String();
            obj.CurrentOrder = isDescending ? c + testClass.DescendingString : c;
            var actual = obj.SortOrder(s);
            var sDes = s + testClass.DescendingString;
            var expected = isSame ? (isDescending ? s : sDes) : sDes;
            areEqual(expected, actual);
        }
    }
}

