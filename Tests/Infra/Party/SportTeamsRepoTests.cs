using eSportSchool.Data.Party;
using eSportSchool.Domain;
using eSportSchool.Domain.Party;
using eSportSchool.Infra;
using eSportSchool.Infra.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eSportSchool.Tests.Infra.Party {
    [TestClass]
    public class SportTeamsRepoTests : SealedRepoTests<SportTeamsRepo, Repo<SportTeam, SportTeamData>, SportTeam, SportTeamData> {
        protected override SportTeamsRepo createObj() => new(GetRepo.Instance<eSportSchoolDB>());

        protected override object? getSet(eSportSchoolDB db) => db.SportTeams;
    }
}
