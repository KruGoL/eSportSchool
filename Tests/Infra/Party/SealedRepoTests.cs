using eSportSchool.Aids;
using eSportSchool.Data;
using eSportSchool.Domain;
using eSportSchool.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace eSportSchool.Tests.Infra.Party {
    public abstract class SealedRepoTests<TClass, TBaseClass, TDomain, TData>
        : SealedBaseTests<TClass, TBaseClass> 
        where TClass : FilteredRepo<TDomain, TData> 
        where TBaseClass : class
        where TDomain : UniqueEntity<TData>,new()
        where TData : UniqueData, new() {
        private static Type esportSchoolType => typeof(eSportSchoolDB);

        private static Type setType => typeof(DbSet<TData>);

        private eSportSchoolDB esportSchoolDb {
            get {
                var o = obj.db;
                isNotNull(o);
                var db = o as eSportSchoolDB;
                isNotNull(db);
                return db;
            }
        }
        protected void instanceTest(object? o, Type t) {
            isNotNull(o);
            isInstanceOfType(o, t);
        }
        protected void instanceTest(object? o, Type t, object? expected) {
            instanceTest(o, t);
            instanceTest(expected,t);
            areEqual(expected, o);
        }
        [TestMethod] public void DbContextTest() => instanceTest(obj.db, esportSchoolType);
        [TestMethod] public void DbSetTest() => instanceTest(obj.set, setType, getSet(esportSchoolDb));
        [TestMethod] public void ToDomainTest() {
            var d = GetRandom.Value<TData>();
            var o = obj.toDomain(d);
            isNotNull(o);
            isInstanceOfType(o, typeof(TDomain));
            areEqualProperties(d, o.Data);
        }
        [TestMethod]
        public void AddFilterTest() {
            string contains(string s) => $"x.{s}.Contains";
            string toStrContains(string s) => $"x.{s}.ToString().Contains";
            obj.CurrentFilter = "abc";
            var q = obj.createSql();
            var s = q.Expression.ToString();
            foreach (var p in typeof(TData).GetProperties()) {
                if (p.Name == nameof(UniqueData.Token)) continue;
                if (p.PropertyType == typeof(string))
                    isTrue(s.Contains(contains(p.Name)), $"No Where found for property {p.Name}");
                else
                    isTrue(s.Contains(toStrContains(p.Name)), $"No Where found for property {p.Name}");
            }
        }
        protected abstract object? getSet(eSportSchoolDB db);
    }
}
