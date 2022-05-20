using eSportSchool.Data.Party;
using eSportSchool.Domain;
using eSportSchool.Domain.Party;
using eSportSchool.Infra;
using eSportSchool.Infra.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eSportSchool.Tests.Infra.Party {
    [TestClass]
    public class TrainersRepoTests : SealedRepoTests<TrainersRepo, Repo<Trainer, TrainerData>, Trainer, TrainerData> {
        protected override TrainersRepo createObj() => new(GetRepo.Instance<eSportSchoolDB>());

        protected override object? getSet(eSportSchoolDB db) => db.Trainers;
    }
}
