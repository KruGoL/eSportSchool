using eSportSchool.Aids;
using eSportSchool.Data.Party;
using eSportSchool.Domain;
using eSportSchool.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace eSportSchool.Tests.Domain.Party
{

    [TestClass]
    public class TrainerTests : SealedClassTests<Trainer, UniqueEntity<TrainerData>> {
        protected override Trainer createObj() => new(GetRandom.Value<TrainerData>());
        [TestMethod] public void FirstNameTest() => isReadOnly(obj.Data.FirstName);
        [TestMethod] public void LastNameTest() => isReadOnly(obj.Data.LastName);
        [TestMethod] public void GenderTest() => isReadOnly(obj.Data.Gender);
        [TestMethod] public void DoBTest() => isReadOnly(obj.Data.DoB);
        [TestMethod] public void ImgPathTest() => isReadOnly(obj.Data.ImgPath);
        [TestMethod] public void FullNameTest() {
            var expected = $"{obj.FirstName} {obj.LastName}";
            areEqual(expected, obj.FullName);
        }
        [TestMethod]
        public void ToStringTest() {
            var expected = $"{obj.FirstName} {obj.LastName} ({obj.Gender.Description()}, {obj.DoB})";
            areEqual(expected, obj.ToString());
        }
        [TestMethod]
        public void SportTeamsTest()
            => itemsTest<ISportTeamsRepo, SportTeam, SportTeamData>(
                d => d.OwnerId = obj.Id, d => new SportTeam(d), () => obj.SportTeams);
        [TestMethod] public void SportTeamsCountTest() {
            var expected = obj.SportTeams?.Count.ToString() ?? "Does not couch anyone";
            areEqual(expected, obj.SportTeamsCount);
        }
    }
}
