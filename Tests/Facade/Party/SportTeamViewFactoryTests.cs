using eSportSchool.Aids;
using eSportSchool.Data.Party;
using eSportSchool.Domain.Party;
using eSportSchool.Facade;
using eSportSchool.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eSportSchool.Tests.Facade.Party {
    [TestClass]
    public class SportTeamViewFactoryTests : SealedClassTests<SportTeamViewFactory, BaseViewFactory<SportTeamView, SportTeam, SportTeamData>>
    {
        [TestMethod] public void CreateTest() { }
        [TestMethod] public void CreateViewTest() {
            var d = GetRandom.Value<SportTeamData>();
            var e = new SportTeam(d);
            var v = new SportTeamViewFactory().Create(e);
            isNotNull(v);
            areEqual(v.CreatedDate, e.CreatedDate);
            areEqual(v.Id, e.Id);
            areEqual(v.OwnerId, e.OwnerId);
            areEqual(v.Name, e.Name);
            areEqual(v.Description, e.Description);
            areEqual(v.FullName, e.ToString());
        }
        [TestMethod] public void CreateEntityTest() {
            var v = GetRandom.Value<SportTeamView>();
            var e = new SportTeamViewFactory().Create(v);
            isNotNull(e);
            areEqual(e.CreatedDate, v.CreatedDate);
            areEqual(e.Id, v.Id);
            areEqual(e.OwnerId, v.OwnerId);
            areEqual(e.Name, v.Name);
            areEqual(e.Description, v.Description);
            areNotEqual(e.ToString(), v.FullName);
        }
    }
}
