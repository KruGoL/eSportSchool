using eSportSchool.Data.Party;
using eSportSchool.Domain;
using eSportSchool.Domain.Party;
using eSportSchool.Infra;
using eSportSchool.Infra.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eSportSchool.Tests.Infra.Party {
    [TestClass]
    public class TrainerSportTeamsRepoTests : SealedRepoTests<TrainerSportTeamsRepo, Repo<TrainerSportTeam, TrainerSportTeamData>, TrainerSportTeam, TrainerSportTeamData> {
        protected override TrainerSportTeamsRepo createObj() => new(GetRepo.Instance<eSportSchoolDB>());

        protected override object? getSet(eSportSchoolDB db) => db.TrainerSportTeams;
    }
}
