using eSportSchool.Data.Party;
using eSportSchool.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace eSportSchool.Tests.Facade.Party
{
    [TestClass]
    public class TrainerViewTests: SealedClassTests<TrainerView>
    {
        [TestMethod] public void IdTest() => IsProperty<string>();
        [TestMethod] public void FirstNameTest() => IsProperty<string?>();
        [TestMethod] public void LastNameTest() => IsProperty<string?>();
        [TestMethod] public void GenderTest() => IsProperty<IsoGender?>();
        [TestMethod] public void DoBTest() => IsProperty<DateTime?>();
        [TestMethod] public void FullNameTest() => IsProperty<string?>();
    }
}
