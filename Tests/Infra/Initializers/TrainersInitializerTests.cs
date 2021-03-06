using eSportSchool.Data.Party;
using eSportSchool.Domain;
using eSportSchool.Infra;
using eSportSchool.Infra.Initializers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eSportSchool.Tests.Infra.Initializers {
    [TestClass] public class TrainersInitializerTests : SealedBaseTests<TrainersInitializer, BaseInitializer<TrainerData>> {
        protected override TrainersInitializer createObj() {
            var db = GetRepo.Instance<eSportSchoolDB>();
            return new TrainersInitializer(db);
        }
    }
}
