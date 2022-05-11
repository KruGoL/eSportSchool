using eSportSchool.Aids;
using eSportSchool.Data.Party;
using eSportSchool.Domain;
using eSportSchool.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eSportSchool.Tests.Domain.Party {
    [TestClass]
    public class TrainerSportTeamTests : SealedClassTests<TrainerSportTeam, UniqueEntity<TrainerSportTeamData>> {
        protected override TrainerSportTeam createObj() => new(GetRandom.Value<TrainerSportTeamData>());
        [TestMethod] public void TrainerIdTest() => isReadOnly(obj.Data.TrainerId);
        [TestMethod] public void STeamIdTest() => isReadOnly(obj.Data.STeamId);
        [TestMethod]
        public void TrainerTest() => itemTest<ITrainersRepo, Trainer, TrainerData>(
            obj.TrainerId, d => new Trainer(d), () => obj.Trainer);
        [TestMethod]
        public void SportTeamTest() => itemTest<ISportTeamsRepo, SportTeam, SportTeamData>(
            obj.STeamId, d => new SportTeam(d), () => obj.SportTeam);
    }
}
