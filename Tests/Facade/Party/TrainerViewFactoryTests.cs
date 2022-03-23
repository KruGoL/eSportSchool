using eSportSchool.Aids;
using eSportSchool.Data.Party;
using eSportSchool.Domain.Party;
using eSportSchool.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eSportSchool.Tests.Facade.Party
{
    [TestClass]
    public class TrainerViewFactoryTests : SealedClassTests<TrainerViewFactory>
    {
        [TestMethod] public void CreateTest() { }
        [TestMethod]
        public void CreateViewTest()
        {
            var d = GetRandom.Value<TrainerData>();
            var e = new Trainer(d);
            var v = new TrainerViewFactory().Create(e);
            isNotNull(v);
            areEqual(v.Gender, e.Gender);
            areEqual(v.Id, e.Id);
            areEqual(v.FirstName, e.FirstName);
            areEqual(v.LastName, e.LastName);
            areEqual(v.DoB, e.DoB);
            areEqual(v.FullName, e.ToString());
        }
        [TestMethod]
        public void CreateEntityTest()
        {
            var v = GetRandom.Value<TrainerView>();
            var e = new TrainerViewFactory().Create(v);
            isNotNull(e);
            areEqual(e.DoB, v.DoB);
            areEqual(e.Id, v.Id);
            areEqual(e.FirstName, v.FirstName);
            areEqual(e.LastName, v.LastName);
            areEqual(e.Gender, v.Gender);
            areNotEqual(e.ToString(), v.FullName);
        }
    }
}
