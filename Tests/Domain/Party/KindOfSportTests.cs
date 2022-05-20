using eSportSchool.Aids;
using eSportSchool.Data.Party;
using eSportSchool.Domain;
using eSportSchool.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eSportSchool.Tests.Domain.Party {
    [TestClass]
    public class KindOfSportTests : SealedClassTests<KindOfSport, NamedEntity<KindOfSportData>> {
        protected override KindOfSport createObj() => new(GetRandom.Value<KindOfSportData>());
        [TestMethod] public void CompareToTest() {
            var dX = GetRandom.Value<KindOfSportData>() as KindOfSportData;
            var dY = GetRandom.Value<KindOfSportData>() as KindOfSportData;
            isNotNull(dX);
            isNotNull(dY);
            var expected = dX.Name?.CompareTo(dY.Name);
            areEqual(expected, new KindOfSport(dX).CompareTo(new KindOfSport(dY)));
        }
    }
}
