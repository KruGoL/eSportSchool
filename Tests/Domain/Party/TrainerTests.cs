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
        [TestMethod] public void FullNameTest() => isInconclusive();
        [TestMethod] public void ToStringTest() => isInconclusive();
        [TestMethod] public void SportTeamsTest() => isInconclusive();
        [TestMethod] public void SportTeamsCountTest() => isInconclusive();
    }
}
