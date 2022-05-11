using eSportSchool.Aids;
using eSportSchool.Data.Party;
using eSportSchool.Domain;
using eSportSchool.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eSportSchool.Tests.Domain.Party
{

    [TestClass]
    public class SportTeamTests : SealedClassTests<SportTeam, NamedEntity<SportTeamData>> {
        protected override SportTeam createObj() => new(GetRandom.Value<SportTeamData>());
        [TestMethod] public void OwnerIdTest() => isReadOnly(obj.Data.OwnerId);
        [TestMethod] public void SportIdTest() => isReadOnly(obj.Data.SportId);
        [TestMethod] public void CreatedDateTest() => isReadOnly(obj.Data.CreatedDate);
        [TestMethod]
        public void ToStringTest() {
            var expected = $"{obj.Name} : {obj.KindOfSport?.Name} ({obj.CreatedDate})";
            areEqual(expected, obj.ToString());
        }
        [TestMethod]
        public void KindOfSportTest() => itemTest<IKindOfSportRepo, KindOfSport, KindOfSportData>(
            obj.SportId, d => new KindOfSport(d), () => obj.KindOfSport);
    }
}
