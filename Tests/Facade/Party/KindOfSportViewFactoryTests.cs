using eSportSchool.Aids;
using eSportSchool.Data.Party;
using eSportSchool.Domain.Party;
using eSportSchool.Facade;
using eSportSchool.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eSportSchool.Tests.Facade.Party {
    [TestClass]
    public class KindOfSportViewFactoryTests : SealedClassTests<KindOfSportViewFactory, BaseViewFactory<KindOfSportView, KindOfSport, KindOfSportData>> {
        [TestMethod] public void CreateTest() { }
        [TestMethod]
        public void CreateViewTest() {
            var d = GetRandom.Value<KindOfSportData>();
            var e = new KindOfSport(d);
            var v = new KindOfSportViewFactory().Create(e);
            isNotNull(v);
            areEqual(v.Id, e.Id);
            areEqual(v.Name, e.Name);
            areEqual(v.Description, e.Description);
        }
        [TestMethod]
        public void CreateEntityTest() {
            var v = GetRandom.Value<KindOfSportView>();
            var e = new KindOfSportViewFactory().Create(v);
            isNotNull(e);
            areEqual(e.Id, v.Id);
            areEqual(e.Name, v.Name);
            areEqual(e.Description, v.Description);
        }
    }
}
