using eSportSchool.Facade;
using eSportSchool.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eSportSchool.Tests.Facade.Party {
    [TestClass]
    public class TrainerSportTeamViewTests : SealedClassTests<TrainerSportTeamView, UniqueView> {
        [TestMethod] public void IdTest() => isProperty<string>();
        [TestMethod] public void TrainerIdTest() => isProperty<string?>();
        [TestMethod] public void STeamIdTest() => isProperty<string?>();
    }

}
