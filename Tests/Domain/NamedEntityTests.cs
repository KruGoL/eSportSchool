using eSportSchool.Aids;
using eSportSchool.Data.Party;
using eSportSchool.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eSportSchool.Tests.Domain {
    [TestClass]
    public abstract class NamedEntityTests : AbstractClassTests<NamedEntity<KindOfSportData>, UniqueEntity<KindOfSportData>> {
        private class testClass : NamedEntity<KindOfSportData> {
            public testClass() : this(new KindOfSportData()) { }
            public testClass(KindOfSportData d) : base(d) { }
        }
        protected override NamedEntity<KindOfSportData> createObj() => new testClass(GetRandom.Value<KindOfSportData>());
        [TestMethod] public void NameTest() => isReadOnly(obj.Data.Name);
        [TestMethod] public void DescriptionTest() => isReadOnly(obj.Data.Description);
    }
}