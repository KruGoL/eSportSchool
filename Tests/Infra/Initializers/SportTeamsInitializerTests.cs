using eSportSchool.Data.Party;
using eSportSchool.Domain;
using eSportSchool.Infra;
using eSportSchool.Infra.Initializers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eSportSchool.Tests.Infra.Initializers {
    [TestClass] public class SportTeamsInitializerTests : SealedBaseTests<SportTeamsInitializer, BaseInitializer<SportTeamData>> {
        protected override SportTeamsInitializer createObj() {
            var db = GetRepo.Instance<eSportSchoolDB>();
            return new SportTeamsInitializer(db);
        }
    }
}
