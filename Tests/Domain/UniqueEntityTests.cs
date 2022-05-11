using eSportSchool.Aids;
using eSportSchool.Data.Party;
using eSportSchool.Domain;
using eSportSchool.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eSportSchool.Tests.Domain {
    [TestClass]
    public class UniqueEntityTests : AbstractClassTests<UniqueEntity<KindOfSportData>, UniqueEntity> {
        private KindOfSportData? d;
        private class testClass : UniqueEntity<KindOfSportData> {
            public testClass() : this(new KindOfSportData()) { }
            public testClass(KindOfSportData d) : base(d) { }
        }
        protected override UniqueEntity<KindOfSportData> createObj() {
            d = GetRandom.Value<KindOfSportData>();
            return new testClass(d);
        }
        [TestMethod] public void IdTest() => isReadOnly(obj.Data.Id);
        [TestMethod] public void DataTest() => isReadOnly(d);
        [TestMethod] public void DefaultStrTest() => areEqual("Undefined", UniqueEntity.DefaultStr);
    }
}

