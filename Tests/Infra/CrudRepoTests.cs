using eSportSchool.Aids;
using eSportSchool.Data.Party;
using eSportSchool.Domain;
using eSportSchool.Domain.Party;
using eSportSchool.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace eSportSchool.Tests.Infra {
    [TestClass]
    public class CrudRepoTests : AbstractClassTests<CrudRepo<SportTeam, SportTeamData>, BaseRepo<SportTeam, SportTeamData>> {
        private eSportSchoolDB? db;
        private DbSet<SportTeamData>? set;
        private SportTeamData? d;
        private SportTeam? s;
        private int cnt;
        private class testClass : CrudRepo<SportTeam, SportTeamData> {
            public testClass(DbContext? c, DbSet<SportTeamData>? s) : base(c, s) { }
            protected internal override SportTeam toDomain(SportTeamData d) => new(d);
        }
        protected override CrudRepo<SportTeam, SportTeamData> createObj() {
            db = GetRepo.Instance<eSportSchoolDB>();
            set = db?.SportTeams;
            isNotNull(set);
            return new testClass(db, set);
        }
        [TestInitialize]
        public override void TestInitialize() {
            base.TestInitialize();
            initSet();
            initKoS();
        }
        private void initSet() {
            cnt = GetRandom.Int32(5, 15);
            for (var i = 0; i < cnt; i++) set?.Add(GetRandom.Value<SportTeamData>());
            _ = db?.SaveChanges();
        }
        private void initKoS() {
            d = GetRandom.Value<SportTeamData>();
            isNotNull(d);
            s = new SportTeam(d);
            var x = obj.Get(d.Id);
            isNotNull(x);
            areNotEqual(d.Id, x.Id);
        }
        [TestMethod] public async Task AddTest() {
            obj.Add(s);
            areEqual(cnt + 1, await set.CountAsync());
        }
        [TestMethod] public async Task AddAsyncTest() {
            isNotNull(s);
            isNotNull(set);
            _ = await obj.AddAsync(s);
            areEqual(cnt + 1, await set.CountAsync());
        }
        [TestMethod] public async Task DeleteTest() {
            await GetTest();
            obj.Delete(d.Id);
            var x = obj.Get(d.Id);
            isNotNull(x);
            areNotEqual(d.Id, x.Id);
        }
        [TestMethod] public async Task DeleteAsyncTest() {
            isNotNull(d);
            await GetTest();
            _ = await obj.DeleteAsync(d.Id);
            var x = obj.Get(d.Id);
            isNotNull(x);
            areNotEqual(d.Id, x.Id);
        }
        [TestMethod] public async Task GetTest() {
            await AddTest();
            var x = obj.Get(d.Id);
            arePropertiesEqual(d, x.Data);
        }
        [DataRow(nameof(SportTeam.Id))]
        [DataRow(nameof(SportTeam.Name))]
        [DataRow(nameof(SportTeam.Description))]
        [DataRow(null)]
        [TestMethod]
        public void GetAllTest(string s) {
            Func<SportTeam, dynamic>? orderBy = null;
            if (s is nameof(SportTeam.Id)) orderBy = x => x.Id;
            else if (s is nameof(SportTeam.Name)) orderBy = x => x.Name;
            else if (s is nameof(SportTeam.Description)) orderBy = x => x.Description;
            var l = obj.GetAll(orderBy);
            areEqual(cnt, l.Count);
            if (orderBy is null) return;
            for (var i = 0; i < l.Count - 1; i++) {
                var a = l[i];
                var b = l[i + 1];
                var aX = orderBy(a) as IComparable;
                var bX = orderBy(b) as IComparable;
                isNotNull(aX);
                isNotNull(bX);
                var r = aX.CompareTo(bX);
                isTrue(r <= 0);
            }
        }
        [TestMethod] public void GetListTest() {
            var l = obj.Get();
            areEqual(cnt, l.Count);
        }
        [TestMethod] public async Task GetAsyncTest() {
            isNotNull(d);
            await AddTest();
            var x = await obj.GetAsync(d.Id);
            arePropertiesEqual(d, x.Data);
        }
        [TestMethod] public async Task GetListAsyncTest() {
            var l = await obj.GetAsync();
            areEqual(cnt, l.Count);
        }
        [TestMethod] public async Task UpdateTest() {
            await GetTest();
            var dX = GetRandom.Value<SportTeamData>() as SportTeamData;
            isNotNull(d);
            isNotNull(dX);
            dX.Id = d.Id;
            var sX = new SportTeam(dX);
            _ = obj.Update(sX);
            var x = obj.Get(d.Id);
            areEqualProperties(dX, x.Data);
        }
        [TestMethod] public async Task UpdateAsyncTest() {
            await GetTest();
            var dX = GetRandom.Value<SportTeamData>() as SportTeamData;
            isNotNull(d);
            isNotNull(dX);
            dX.Id = d.Id;
            var sX = new SportTeam(dX);
            _ = await obj.UpdateAsync(sX);
            var x = obj.Get(d.Id);
            areEqualProperties(dX, x.Data);
        }
    }
}

