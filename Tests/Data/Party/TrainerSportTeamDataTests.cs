using eSportSchool.Data;
using eSportSchool.Data.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eSportSchool.Tests.Data.Combined {
    [TestClass]
    public class TrainerSportTeamDataTests : SealedClassTests<TrainerSportTeamData, UniqueData> {
        [TestMethod] public void TrainerIdTest() => isProperty<string>();
        [TestMethod] public void STeamIdTest() => isProperty<string>();
    }
}
