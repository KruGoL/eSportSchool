using eSportSchool.Data.Party;
using eSportSchool.Domain;
using eSportSchool.Infra;
using eSportSchool.Infra.Initializers;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace eSportSchool.Tests.Infra.Initializers {
    [TestClass]
    public class BaseInitializerTests
    : AbstractClassTests<BaseInitializer<SportTeamData>, object> {
        private class testClass : BaseInitializer<SportTeamData> {
            public testClass(DbContext? c, DbSet<SportTeamData>? s) : base(c, s) { }
            protected override IEnumerable<SportTeamData> getEntities => throw new NotImplementedException();
        }
        protected override BaseInitializer<SportTeamData> createObj() {
            var db = GetRepo.Instance<eSportSchoolDB>();
            var set = db?.SportTeams;
            return new testClass(db, set);
        }
    }
}
