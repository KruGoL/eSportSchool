using eSportSchool.Data.Party;
using eSportSchool.Domain.Party;
using eSportSchool.Facade;
using eSportSchool.Facade.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace eSportSchool.Tests.Facade.Party
{
    [TestClass]
    public class TrainerViewTests: SealedClassTests<TrainerView, UniqueView>
    {
        [TestMethod] public void IdTest() => isProperty<string>();
        [TestMethod] public void FirstNameTest() => isProperty<string?>();
        [TestMethod] public void LastNameTest() => isProperty<string?>();
        [TestMethod] public void GenderTest() => isProperty<IsoGender>();
        [TestMethod] public void DoBTest() => isProperty<DateTime?>();
        [TestMethod] public void DescriptionTest() => isProperty<string?>();
        [TestMethod] public void FullNameTest() => isProperty<string?>();
        [TestMethod] public void SportTeamsCountTest() => isProperty<string?>();
    }
}
