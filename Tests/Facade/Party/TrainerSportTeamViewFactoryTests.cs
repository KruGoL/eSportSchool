using eSportSchool.Aids;
using eSportSchool.Data.Party;
using eSportSchool.Domain.Party;
using eSportSchool.Facade;
using eSportSchool.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eSportSchool.Tests.Facade.Party {
    [TestClass]
    public class TrainerSportTeamViewFactoryTests : SealedClassTests<TrainerSportTeamViewFactory, BaseViewFactory<TrainerSportTeamView, TrainerSportTeam, TrainerSportTeamData>> {
        [TestMethod] public void CreateTest() { }
        [TestMethod]
        public void CreateViewTest() {
            var d = GetRandom.Value<TrainerSportTeamData>();
            var e = new TrainerSportTeam(d);
            var v = new TrainerSportTeamViewFactory().Create(e);
            isNotNull(v);
            areEqual(v.Id, e.Id);
            areEqual(v.TrainerId, e.TrainerId);
            areEqual(v.STeamId, e.STeamId);
        }
        [TestMethod]
        public void CreateEntityTest() {
            var v = GetRandom.Value<TrainerSportTeamView>();
            var e = new TrainerSportTeamViewFactory().Create(v);
            isNotNull(e);
            areEqual(e.Id, v.Id);
            areEqual(e.TrainerId, v.TrainerId);
            areEqual(e.STeamId, v.STeamId);
        }
    }
}
