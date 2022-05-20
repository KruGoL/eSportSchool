using eSportSchool.Aids;
using eSportSchool.Data.Party;
using eSportSchool.Domain;
using eSportSchool.Domain.Party;
using eSportSchool.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eSportSchool.Tests.Infra {
    [TestClass] public class BaseRepoTests : AbstractClassTests<BaseRepo<SportTeam, SportTeamData>, object> {
        private class testClass : BaseRepo<SportTeam, SportTeamData> {
            public testClass(DbContext? c, DbSet<SportTeamData>? s) : base(c, s) { }
            public override bool Add(SportTeam obj) => throw new NotImplementedException();
            public override Task<bool> AddAsync(SportTeam obj) => throw new NotImplementedException();
            public override bool Delete(string id) => throw new NotImplementedException();
            public override Task<bool> DeleteAsync(string id) => throw new NotImplementedException();
            public override List<SportTeam> Get() => throw new NotImplementedException();
            public override SportTeam Get(string id) => throw new NotImplementedException();
            public override List<SportTeam> GetAll(Func<SportTeam, dynamic>? orderBy = null)
                => throw new NotImplementedException();
            public override Task<List<SportTeam>> GetAsync() => throw new NotImplementedException();
            public override Task<SportTeam> GetAsync(string id) => throw new NotImplementedException();
            public override bool Update(SportTeam obj) => throw new NotImplementedException();
            public override Task<bool> UpdateAsync(SportTeam obj) => throw new NotImplementedException();
        }
        protected override BaseRepo<SportTeam, SportTeamData> createObj() => new testClass(null, null);
        [TestMethod] public void dbTest() => isReadOnly<DbContext?>();
        [TestMethod] public void setTest() => isReadOnly<DbSet<SportTeamData>?>();
        [TestMethod] public void BaseRepoTest() {
            var db = GetRepo.Instance<eSportSchoolDB>();
            var set = db?.SportTeams;
            isNotNull(set);
            obj = new testClass(db, set);
            areEqual(db, obj.db);
            areEqual(set, obj.set);
        }
        [TestMethod] public async Task ClearTest() {
            BaseRepoTest();
            var cnt = GetRandom.Int32(5, 30);
            var db = obj.db;
            isNotNull(db);
            var set = obj.set;
            isNotNull(set);
            for (var i = 0; i < cnt; i++) set.Add(GetRandom.Value<SportTeamData>());
            areEqual(0, await set.CountAsync());
            db.SaveChanges();
            areEqual(cnt, await set.CountAsync());
            obj.clear();
            areEqual(0, await set.CountAsync());
        }
        [TestMethod] public void AddTest() => isAbstractMethod(nameof(obj.Add), typeof(SportTeam));
        [TestMethod] public void AddAsyncTest() => isAbstractMethod(nameof(obj.AddAsync), typeof(SportTeam));
        [TestMethod] public void DeleteTest() => isAbstractMethod(nameof(obj.Delete), typeof(string));
        [TestMethod] public void DeleteAsyncTest() => isAbstractMethod(nameof(obj.DeleteAsync), typeof(string));
        [TestMethod] public void GetTest() => isAbstractMethod(nameof(obj.Get), typeof(string));
        [TestMethod] public void GetAllTest() => isAbstractMethod(nameof(obj.GetAll), typeof(Func<SportTeam, dynamic>));
        [TestMethod] public void GetListTest() => isAbstractMethod(nameof(obj.Get));
        [TestMethod] public void GetAsyncTest() => isAbstractMethod(nameof(obj.GetAsync), typeof(string));
        [TestMethod] public void GetListAsyncTest() => isAbstractMethod(nameof(obj.GetAsync));
        [TestMethod] public void UpdateTest() => isAbstractMethod(nameof(obj.Update), typeof(SportTeam));
        [TestMethod] public void UpdateAsyncTest() => isAbstractMethod(nameof(obj.UpdateAsync), typeof(SportTeam));
    }
}

