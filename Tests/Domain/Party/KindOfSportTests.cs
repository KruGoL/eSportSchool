using eSportSchool.Aids;
using eSportSchool.Data.Party;
using eSportSchool.Domain;
using eSportSchool.Domain.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace eSportSchool.Tests.Domain.Party {
    [TestClass]
    public class KindOfSportTests : SealedClassTests<KindOfSport, NamedEntity<KindOfSportData>> {
        protected override KindOfSport createObj() => new(GetRandom.Value<KindOfSportData>());
    }
}
