using eSportSchool.Data.Party;
using eSportSchool.Domain;
using eSportSchool.Infra;
using eSportSchool.Infra.Initializers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eSportSchool.Tests.Infra.Initializers {
    [TestClass]
    public class TrainerSportTeamsInitializerTests : SealedBaseTests<TrainerSportTeamsInitializer, BaseInitializer<TrainerSportTeamData>> {
        protected override TrainerSportTeamsInitializer createObj() {
            var db = GetRepo.Instance<eSportSchoolDB>();
            return new TrainerSportTeamsInitializer(db);
        }
    }
}
