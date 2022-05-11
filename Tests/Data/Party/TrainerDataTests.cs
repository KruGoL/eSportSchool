using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using eSportSchool.Data.Party;
using eSportSchool.Data;

namespace eSportSchool.Tests.Data.Party
{
    [TestClass]
    public class TrainerDataTests: SealedClassTests<TrainerData, UniqueData>
    {
        [TestMethod] public void FirstNameTest() => isProperty<string?>();
        [TestMethod] public void LastNameTest() => isProperty<string?>();
        [TestMethod] public void GenderTest() => isProperty<IsoGender?>();
        [TestMethod] public void DoBTest() => isProperty<DateTime?>();
    }
}
