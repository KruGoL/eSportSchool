using eSportSchool.Aids;
using eSportSchool.Data.Party;
using eSportSchool.Domain;
using eSportSchool.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eSportSchool.Tests.Domain.Combined {
    [TestClass]
    public class TrainerSportTeamTests : SealedClassTests<TrainerSportTeam, UniqueEntity<TrainerSportTeamData>> {
        protected override TrainerSportTeam createObj() => new(GetRandom.Value<TrainerSportTeamData>());
        [TestMethod] public void TrainerIdTest() => isReadOnly(obj.Data.TrainerId);
        [TestMethod] public void STeamIdTest() => isReadOnly(obj.Data.STeamId);
        [TestMethod] public void TrainerTest() => isInconclusive();
        [TestMethod] public void SportTeamTest() => isInconclusive();
    }
}
